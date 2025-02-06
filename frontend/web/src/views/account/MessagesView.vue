<template>
  <div class="home-bg">
    <h1 align="center" :style="{color: 'brown'}">Mesaje</h1>
    <v-container fill height>
      <v-row>
        <v-col></v-col>
        <v-col>
          <h3 align="center" :style="{color: 'brown'}">Alege persoana cu care doresti o conversatie</h3>
        </v-col>
        <v-col>
          <v-combobox rounded
                      background-color=white
                      :items="users"
                      :item-text="(o) => (o)['firstName'] + ' ' + (o)['lastName']"
                      label="Selectati persoana"
                      outlined
                      dense
                      @change="selectUser"
          ></v-combobox>
        </v-col>
        <v-col></v-col>
      </v-row>
      <v-row>

        <v-col>
          <v-textarea v-model="newMessage.content"
                      rows="2"
                      label="Scrieti mesajul"
                      rounded
                      background-color="white"
                      outlined
                      dense
                      required
          ></v-textarea>
        </v-col>
        <v-col>
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="sendMessage"
            >Trimite</v-btn>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <div :key="k">
            <v-row v-for="message in messages">
              <v-col>
                <v-card outlined>
                        <v-card-title> {{ users.find(u => u.id === message.senderId).firstName }}
                                      {{ users.find(u => u.id === message.senderId).lastName }}</v-card-title>
                        <v-card-subtitle> {{ message.content }} </v-card-subtitle>
                        <v-card-text> {{ message.date }}</v-card-text>
                </v-card>
              </v-col>
            </v-row>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
import io from "socket.io-client"

const socket = io.connect("http://localhost:8083")
const sendMsg = async (username) => {
  socket.emit("send_message",{message : "Mesaj trimis cu succes"})
  this.messages = (await axios.get('https://localhost:7244/messages/user/'+this.currentUser.id
      +'/user/'+this.newMessage.receiverId)).data
  this.k = 1 - this.k
}

export default {
  name: "MessagesView",
  data(){
    return {
      socket: {},
      connectedStatus: '',
      currentUser: null,
      users: [],
      newMessage: {},
      content: '',
      messages: [],
      k: 0,
    }
  },

  async mounted(){
    this.currentUser = (await axios.get("https://localhost:7244/users/"
        + window.sessionStorage.getItem("userId"))).data;
    this.users = (await axios.get('https://localhost:7244/users/list')).data;
    this.newMessage.senderId = this.currentUser.id;
  },

  methods: {
    sendMessage: async function() {
        this.newMessage.date = new Date();
        await axios.post('https://localhost:7244/messages', this.newMessage)
        console.log('mesaj trimis cu succes')
        await sendMsg(this.currentUser.firstName+' '+this.currentUser.lastName)
    },

    async selectUser(e){
      this.newMessage.receiverId = e.id
      this.messages = (await axios.get('https://localhost:7244/messages/user/'+this.currentUser.id
          +'/user/'+this.newMessage.receiverId)).data
      this.k = 1 - this.k
    }
  }
}
</script>

<style scoped>

</style>