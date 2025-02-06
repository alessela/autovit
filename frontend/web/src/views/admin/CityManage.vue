<template>
  <div class ="manage-bg">
    <h1 style ="color:brown" align="center">
      Orase
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza oras</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="counties"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza judet"
                        outlined
                        dense
                        @change="selectCounty"
            ></v-combobox>
            <v-combobox rounded
                        background-color=white
                        :items="cities"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza oras"
                        outlined
                        dense
                        v-on:input="selectCity"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="copyCity"
            >Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Oras selectat</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox
                @change="renderKey=1-renderKey"
                :key="renderKey"
                v-model="selCounty"
                label="Judet"
                background-color="white"
                :items="counties"
                :item-text="(o) => (o)['name']"
                outlined
                dense
                rounded
                required
            ></v-combobox>
            <v-text-field v-model="selCityCopy.name"
                          label="Oras"
                          background-color="white"
                          outlined
                          dense
                          rounded
                          required
            >
            </v-text-field>
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="updateCity"
            >Editeaza</v-btn>
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="deleteCity"
            >Sterge</v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color:'brown'}">Creeaza oras</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox
                @change="renderKey2=1-renderKey2"
                :key="renderKey2"
                v-model="newCounty"
                label="Judet"
                background-color="white"
                :items="counties"
                :item-text="(o) => (o)['name']"
                outlined
                dense
                rounded
                required
            ></v-combobox>
            <v-text-field v-model="newCity.name"
                          label="Oras"
                          background-color="white"
                          outlined
                          dense
                          rounded
                          required
            ></v-text-field>
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="createCity"
            >Creeaza
            </v-btn>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
        <v-col></v-col>
        <v-col align="center" justify="center">
          <v-btn
              class="ml-6 mr-6"
              color="white"
              rounded
              :style="{color:'brown'}"
              @click="$router.push('.')"
          > Inapoi
          </v-btn>
        </v-col>
        <v-col></v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "CityManage",
  data(){
    return{
      counties: [],
      cities: [],
      selCity: null,
      selCityCopy: {},
      newCity: {},
      selCounty: null,
      newCounty: null,
      renderKey: 0,
      renderKey2: 0,
    }
  },

  async created(){
    this.counties = (await axios.get("https://localhost:7244/counties/list")).data;
  },

  methods:{
    async selectCounty(e){
      this.cities = (await axios.get("https://localhost:7244/cities/county/" + e.id)).data
    },

    selectCity(e){
      this.selCity = e
    },

    async copyCity(){
      try{
        this.selCityCopy=this.selCity
        this.selCounty = (await axios.get("https://localhost:7244/counties/" + this.selCity.countyId)).data
        this.renderKey = 1 - this.renderKey
      }catch (e) {
        alert('Nu ati selectat un oras!')
      }

    },

    async updateCity(){
      try{
        this.selCityCopy.countyId = this.selCounty.id
        await axios.put("https://localhost:7244/cities", this.selCityCopy)
        alert("Oras modificat cu succes")
      }catch (e) {
        alert("Nu ati selectat un oras!")
      }
    },

    async deleteCity(){
      try{
        await axios.delete('https://localhost:7244/cities/'+this.selCityCopy.id)
        this.cities = (await axios.get('https://localhost:7244/cities/county/' + this.selCityCopy.countyId)).data
        alert("Oras sters cu succes")
      }catch (e) {
        alert('Nu ati selectat un oras!')
      }
    },

    async createCity(){
      try{
        this.newCity.countyId = this.newCounty.id
        await axios.post('https://localhost:7244/cities', this.newCity)
        alert('Oras creat cu succes')
      }catch (e) {
        alert('Nu ati selectat un judet')
      }

    }

  }
}
</script>

<style scoped>

</style>