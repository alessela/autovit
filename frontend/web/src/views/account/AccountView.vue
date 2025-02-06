<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Detalii cont
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="userCopy.firstName"
                label="Prenume"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-text-field
              v-model="userCopy.lastName"
              label="Nume"
              background-color="white"
              outlined
              dense
              rounded
              required
            ></v-text-field>
            <v-text-field
                v-model="userCopy.email"
                label="Email"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-text-field
                v-model="userCopy.password"
                label="Parola"
                type="password"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-text-field
                v-model="userCopy.phoneNumber"
                label="Numar de telefon"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-text-field
                v-model="userCopy.address"
                label="Numar de telefon"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-combobox :key="renderKey"
                        v-model="county"
                        :items="counties"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza judet"
                        background-color="white"
                        outlined
                        dense
                        rounded
                        required
                        @change="selectCounty"
            ></v-combobox>
            <v-combobox :key="renderKey1"
                        v-model="city"
                        :items="cities"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza oras"
                        background-color="white"
                        outlined
                        dense
                        rounded
                        required
                        @change="selectCity"
            ></v-combobox>
            <v-btn
              class="ml-6 mr-6"
              color="white"
              rounded
              :style="{color:'brown'}"
              @click="updateUser"
            > Modifica detalii cont
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteDialog = true"
            > Sterge cont
            </v-btn>
            <v-dialog
                v-model="deleteDialog"
                max-width="300"
            >
              <v-card>
                <v-card-title class="justify-center">
                  Sigur iti stergi contul?
                  <v-card-actions class="justify-center">
                    <v-btn
                        class="ml-6 mr-6"
                        color="white"
                        rounded
                        :style="{color:'brown'}"
                        @click="deleteUser"
                    > Sterge
                    </v-btn>
                  </v-card-actions>
                </v-card-title>
              </v-card>
            </v-dialog>
          </v-form>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "AccountView",
  data(){
    return{
      currentUser: null,
      userCopy: {},
      deleteDialog: false,
      renderKey: 0,
      renderKey1: 0,
      city: null,
      county: null,
      counties: [],
      cities: [],
    }
  },

  async created(){
    this.currentUser = (await axios.get("https://localhost:7244/users/"
        + window.sessionStorage.getItem("userId"))).data;
    this.userCopy = this.currentUser
    this.city = (await axios.get("https://localhost:7244/cities/"+this.userCopy.cityId)).data
    this.county = (await axios.get("https://localhost:7244/counties/" + this.city.countyId)).data
    this.counties = (await axios.get("https://localhost:7244/counties/list")).data
  },

  methods:{
    async selectCounty(e){
      this.cities = (await axios.get("https://localhost:7244/cities/county/" + e.id)).data
      this.county = e
      this.renderKey=1-this.renderKey
    },

    selectCity(e){
      this.userCopy.cityId = e.id
      this.renderKey1=1-this.renderKey1
    },

    async updateUser(){
      try{
        await axios.put("https://localhost:7244/users", this.userCopy)
        this.$router.go(0);
      }
      catch(e){
        alert('Acest email este deja asociat unui cont!')
      }
    },

    async deleteUser(){
      await axios.delete("https://localhost:7244/users/"+this.currentUser.id)
      window.sessionStorage.setItem("userId", null)
      window.location.href = '/login'
    }
  }
}
</script>