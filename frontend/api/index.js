const express = require('express')
const bodyParser = require('body-parser');
const cors = require('cors');
const uuid = require('uuid');

const app = express();
const port = 3000;

const neo4j = require('neo4j-driver');
const driver = neo4j.driver("bolt://localhost:7687");
neo4j.auth.basic("neo4j", "cats");

app.use(cors());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.post('/cats/login', (req, res) => {
    const session = driver.session();
    var query = "MATCH (c:Cat{name: $name, password: $password }) RETURN { id: c.id }";
    session.run(query, req.body).then(result => {
        res.status(200).send(result.records[0]._fields[0]);
    }).catch(e => {
        console.log(e);
        res.sendStatus(400);
    }).finally(() => session.close());
});

app.post('/cats', (req, res) => {
    const session = driver.session();
    var query = "CREATE (c:Cat{id: $id, name: $name, age: $age, description: $description, password: $password, photos: $photos })";
    let cat = req.body;
    cat.id = uuid.v4();
    session.run(query, cat).then(result => {
        console.log("Profile created!");
        res.sendStatus(200);
    }).catch(e => {
        console.log(e);
        console.log("Error creating profile");
        res.sendStatus(400);
    }).finally(() => session.close());
});

app.post('/cats/:id/react', (req, res) => {
    const session = driver.session();
    var query = 'MATCH (sender:Cat{ id: $senderId }) MATCH (receiver:Cat{ id: $receiverId }) CREATE (sender)-[:REACTED_TO{reaction: $reaction}]->(receiver)';
    session.run(query, { senderId: req.params.id, receiverId: req.body.id, reaction: req.body.reaction }).then(result => {
        if (req.body.reaction !== 'LIKE')
        {
            res.status(200).send(false);
        }
        const session2 = driver.session();
        var query2 = 'MATCH (sender:Cat{ id: $senderId })<-[r:REACTED_TO{reaction: "LIKE" }]-(receiver:Cat{ id: $receiverId }) RETURN r IS NOT NULL';
        session2.run(query2, { senderId: req.params.id, receiverId: req.body.id }).then(result2 => {
            var matched = result2.records[0] ? true : false;
            if (matched) {
                const session3 = driver.session();
                var query3 = 'MATCH (sender:Cat{ id: $senderId }) MATCH (receiver:Cat{ id: $receiverId }) CREATE (sender)-[:MATCHED]->(receiver)';
                session3.run(query3, { senderId: req.params.id, receiverId: req.body.id });
            }
            res.status(200).send(matched);
        }).catch(e2 => {
            console.log(e2);
            res.sendStatus(400);
        }).finally(() => session2.close());
    }).catch(e => {
        console.log(e);
        res.sendStatus(400);
    }).finally(() => session.close());
});

app.get('/cats/:id/available', (req, res) => {
    const session = driver.session();
    var query = "MATCH (c:Cat{id: $id}) MATCH (a:Cat) WHERE NOT (a)<-[:REACTED_TO]-(c) AND a.id <> $id RETURN a";
    session.run(query, {id: req.params.id }).then(result => {
        var matches = result.records.map(r => {
            var properties = r._fields[0].properties;
            return {
                id: properties.id,
                name: properties.name,
                age: properties.age,
                description: properties.description,
                photos: properties.photos
            }
        })
        res.status(200).send(matches);
    }).catch(e => {
        console.log(e);
        res.sendStatus(400);
    }).finally(() => session.close());
});

app.get('/cats/:id/matches', (req, res) => {
    const session = driver.session();
    var query = "MATCH (c:Cat{id: $id})-[:MATCHED]-(matches:Cat) RETURN matches";
    session.run(query, {id: req.params.id }).then(result => {
        var matches = result.records.map(r => {
            var properties = r._fields[0].properties;
            return {
                id: properties.id,
                name: properties.name,
                age: properties.age,
                description: properties.description,
                photos: properties.photos
            }
        })
        res.status(200).send(matches);
    }).catch(e => {
        console.log(e);
        res.sendStatus(400);
    }).finally(() => session.close());
});


app.listen(port, () => console.log(`Hello world app listening on port ${port}!`));