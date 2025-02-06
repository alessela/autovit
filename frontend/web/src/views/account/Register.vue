<template>
  <div class="main-bg">
    <v-container fill-height>
      <v-row></v-row>
      <v-row>
        <v-col></v-col>
        <v-col align="center" justify="center"
               :style="{
          backgroundColor: 'black',
          opacity: 0.5
        }">
          <h1 style="color:white">Inregistreaza-te</h1>
          <v-form
              ref="form"
              class="ml-6 mr-6"
          >
            <v-text-field
                class="text-white"
                v-model="newUser.firstName"
                label="Prenume"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                v-model="newUser.lastName"
                label="Nume"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                v-model="newUser.email"
                label="Email"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                v-model="newUser.password"
                label="Parola"
                type="password"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                v-model="newUser.phoneNumber"
                label="Numar de telefon"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                v-model="newUser.address"
                label="Adresa"
                background-color=rgb(127,127,127)
                rounded
                required
            ></v-text-field>

            <v-combobox rounded
                        required
                        background-color=rgb(127,127,127)
                        :items="counties"
                        :item-text="(o) => (o)['name']"
                        label="Judet"
                        @change="selectCounty"
            ></v-combobox>
            <v-combobox rounded
                        required
                        :key="k"
                        v-model="city"
                        background-color=rgb(127,127,127)
                        :items="cities"
                        :item-text="(o) => (o)['name']"
                        label="Oras"
                        @change="k=1-k"
            ></v-combobox>

            <v-btn
                text
                :style="{color:'white'}"
                rounded
                @click="register"
            >
              Sign Up
            </v-btn>

            <v-btn
                text
                :style="{color:'white'}"
                rounded
                @click="$router.push('login');"
            >
              Login
            </v-btn>
          </v-form>
        </v-col>
        <v-col></v-col>
      </v-row>
      <v-row></v-row>

    </v-container>
  </div>
</template>

<script>
  import axios from "axios";
  export default {
    name: 'Register',
    data() {
      return {
        newUser: {},
        k: 0,
        counties: [],
        cities: [],
        city: null
      }
    },

    async created(){
      this.counties = (await axios.get('https://localhost:7244/counties/list')).data
    },

    methods: {
      async selectCounty(e){
        this.cities = (await axios.get('https://localhost:7244/cities/county/'+e.id)).data
      },

      async register() {
        try {
          this.newUser.isAdmin = false
          this.newUser.cityId = this.city.id
          window.sessionStorage.setItem("userId",
              (await axios.post("https://localhost:7244/users",this.newUser)).data.id);
          window.location.href = '/';
        } catch (e) {
          alert("Date incomplete!")
        }
      }
    }
  }
</script>

<style>
.text-white input {
  color: white !important;
}
</style>