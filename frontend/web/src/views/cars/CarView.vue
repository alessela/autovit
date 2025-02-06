<template>
  <div class="home-bg">
    <v-container fill-height>
      <v-row>
        <v-col>
          <v-img class="carView"
                 :style="{ 'background-image': `url(${currentCar.image})` }">
          </v-img>
        </v-col>
        <v-col>
          <h2 :style="{color: 'brown'}"> {{currentCar.name }}</h2>
          <v-container>
            <v-row>
              <v-col>
                <ul>
                  <li>{{currentCar.year}}</li>
                  <li>{{currentCar.mileage }} km</li>
                  <li>{{ getFuelNameByCar(currentCar) }}</li>
                </ul>
                <v-icon>mdi-map-marker</v-icon>{{ getSeller(currentCar).address }},
                {{ getCityByCar(currentCar).name }},
                {{ counties.find(c => c.id === getCityByCar(currentCar).countyId).name }}
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <h2 :style="{color: '#cc0000'}"> {{currentCar.price}} EUR</h2>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-btn class="ml-6 mr-6"
                       color="white"
                       :style="{color:'brown'}"
                       rounded
                >Trimite mesaj</v-btn>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <p> <b>Numar de telefon:</b> {{ getSeller(currentCar).phoneNumber }}</p>
              </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col>
                <v-btn v-if="currentCar.sellerId === currentUser.id"
                       class="ml-6 mr-6"
                       color="white"
                       :style="{color:'brown'}"
                       @click="$router.push(currentCar.id+'/edit')"
                       rounded
                >Editeaza</v-btn>
                <h3 :style="{color: '#cc0000'}" v-if="soldCars.some(sc => sc.carId === this.currentCar.id)">
                  Masina este deja vanduta!</h3>
                <v-btn v-else-if="currentCar.sellerId !== currentUser.id"
                       class="ml-6 mr-6"
                       color="white"
                       :style="{color:'brown'}"
                       @click="buyCar"
                       rounded
                >Cumpara!</v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <h2 :style="{color: 'brown'}"> Detalii </h2>
        </v-col>
      </v-row>
      <v-spacer></v-spacer>
      <v-row>
        <v-col>
          <v-container>
            <v-row>
              <v-col> <b>Marca</b> </v-col>
              <v-col> {{ brands.find(b => b.id === getModelByCar(currentCar).brandId).name }} </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col> <b>Model </b></v-col>
              <v-col> {{ getModelByCar(currentCar).name}}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col> <b>An</b></v-col>
              <v-col> {{ currentCar.year }}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col> <b>Km</b></v-col>
              <v-col>{{currentCar.mileage}} km</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Combustibil</b></v-col>
              <v-col>{{ getFuelNameByCar(currentCar) }}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Putere</b></v-col>
              <v-col>{{ currentCar.power}} CP</v-col>
            </v-row>
          </v-container>
        </v-col>
        <v-col>
          <v-container>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Capacitate cilindrica</b></v-col>
              <v-col>{{ currentCar.engine}} cm3</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Cutie de viteze</b></v-col>
              <v-col>{{ transmissions.find(t => t.id === currentCar.transmissionId).name }}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Tip caroserie</b></v-col>
              <v-col>{{ bodyStyles.find(b => b.id === currentCar.bodyStyleId).name }}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Culoare</b></v-col>
              <v-col> {{ colors.find(c => c.id === currentCar.colorId).name }}</v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col><b>Stare</b></v-col>
              <v-col v-if="currentCar.new"> nou</v-col>
              <v-col v-else>utilizat</v-col>
            </v-row>
          </v-container>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <h2 :style="{color: 'brown'}"> Descriere </h2>
        </v-col>
      </v-row>
      <v-spacer></v-spacer>
      <v-row>
        <v-col>{{currentCar.description}}</v-col>
      </v-row>
      <v-row>
        <v-col>
          <h2 :style="{color: 'brown'}"> Raport istoric </h2>
        </v-col>
      </v-row>
      <v-row>
        <v-col align="center" justify="center">
          <v-list rounded outlined dense>
            <v-list-item-group
                color="primary">
              <v-list-item v-for="event in events">
                <v-list-item-content>
                  <v-list-item-title> {{ event.name}} -- {{ getMonthByDateString(event.date)}}
                    {{ getYearByDateString(event.date)}}</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </v-col>
        <v-col></v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
import io from "socket.io-client"

const socket = io.connect("http://localhost:8083")
const sendMessage = () => {
  socket.emit("send_message",{message : "Car bought"})
}

socket.on("receive_message",(data) => {
  alert(data.message)
})

export default {
  name: "CarView",

  data(){
    return {
      currentCar: null,
      currentUser: null,
      brands: [],
      models: [],
      fuels: [],
      users: [],
      cities: [],
      counties: [],
      transmissions: [],
      bodyStyles: [],
      colors: [],
      months: ['ianuarie', 'februarie', 'martie', 'aprilie', 'mai', 'iunie', 'iulie', 'august', 'septembrie',
        'octombrie', 'noiembrie', 'decembrie'],
      events: [],
      soldCars: [],
    }
  },

  async created(){
    this.currentUser = (await axios.get("https://localhost:7244/users/"
        + window.sessionStorage.getItem("userId"))).data;
    const split = this.$route.path.split('/')
    this.currentCar = (await axios.get('https://localhost:7244/cars/'+split[split.length-1])).data
    this.brands = (await axios.get('https://localhost:7244/brands/list')).data
    this.models = (await axios.get('https://localhost:7244/models/list')).data
    this.fuels = (await axios.get('https://localhost:7244/fuels/list')).data
    this.users = (await axios.get('https://localhost:7244/users/list')).data
    this.cities = (await axios.get('https://localhost:7244/cities/list')).data
    this.counties = (await axios.get('https://localhost:7244/counties/list')).data
    this.transmissions = (await axios.get('https://localhost:7244/transmissions/list')).data
    this.bodyStyles = (await axios.get('https://localhost:7244/body_styles/list')).data
    this.colors = (await axios.get('https://localhost:7244/colors/list')).data
    this.events = (await axios.get('https://localhost:7244/car_events/car/'+this.currentCar.id)).data
    this.soldCars = (await axios.get('https://localhost:7244/sold_cars/list')).data
  },

  methods:{
    getCityByCar: function(car){
      return this.cities.find(c => c.id === this.users.find(u => u.id === car.sellerId).cityId)
    },

    getSeller: function (car){
      return this.users.find(u => u.id === car.sellerId)
    },

    getModelByCar: function(car){
      return this.models.find(u => u.id === car.modelId)
    },

    getFuelNameByCar: function (car){
      return this.fuels.find(f => f.id === car.fuelId).name
    },

    getMonthByDateString(date){
      return this.months[new Date(date).getMonth()]
    },

    getYearByDateString(date){
      return new Date(date).getFullYear()
    },

    getMonthIndex(date){
      return new Date(date).getMonth() + 1;
    },

    async buyCar(){
      await axios.post('https://localhost:7244/sold_cars', {carId: this.currentCar.id, buyerId: this.currentUser.id})
      alert('Felicitari, ati cumparat masina cu succes!')
      sendMessage()
      this.$router.go(0);
    }
  }
}
</script>

<style scoped>
.carView {
  display: block;
  cursor: pointer;
  width: 800px;
  height: 600px;
  margin: 0 auto 20px;
  background-position: center center;
  background-size: contain;
}

.home-bg {
  background-color: rgb(255, 255, 204);
  background-size: cover;
  width:100%;
  height: 100%;
}

</style>