<template>
  <div class="home-bg">
    <h1 style="color:brown" align="center">Masini cumparate</h1>
    <v-container>
      <div>
        <v-row v-for="car in cars">
          <v-col>
            <v-card outlined width="1000" :to="'/cars/'+car.id">
              <v-container>
                <v-row>
                  <v-col>
                    <v-img class="carThumbnail"
                           :style="{ 'background-image': `url(${car.image})` }">
                    </v-img>
                  </v-col>
                  <v-col>
                    <v-card-title v-text="car.name"></v-card-title>
                    <v-card-subtitle>
                      <ul>
                        <li>{{car.year}}</li>
                        <li>{{car.mileage}} km</li>
                        <li>{{car.engine}} cm3</li>
                        <li>{{ fuels.find(f => f.id === car.fuelId).name}}</li>
                      </ul>
                    </v-card-subtitle>
                    <v-card-text>
                      <v-icon>mdi-map-marker</v-icon>
                      {{ getCityByCar(car).name }},
                      {{ getCountyByCar(car).name }}
                    </v-card-text>
                  </v-col>
                  <v-col>
                    <h3 :style="{color: '#cc0000'}">
                      {{car.price}} EUR
                    </h3>
                  </v-col>
                </v-row>
              </v-container>
            </v-card>
          </v-col>
        </v-row>
        <v-row>
          <v-col align="center" justify="center">
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="$router.push('.')"
            >Inapoi</v-btn>
          </v-col>
        </v-row>
      </div>
    </v-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "BoughtCars",

  data(){
    return{
      cars: [],
      currentUser: null,
      fuels: [],
      soldCars: [],
      cities: [],
      counties: [],
      users: []
    }
  },

  async created(){
    this.currentUser = (await axios.get("https://localhost:7244/users/"
        + window.sessionStorage.getItem("userId"))).data;
    this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data
    this.soldCars = (await axios.get("https://localhost:7244/sold_cars/list")).data
    this.cars = (await axios.get('https://localhost:7244/cars/list')).data
        .filter(c => this.soldCars.some(sc => sc.carId === c.id && sc.buyerId === this.currentUser.id))
    this.counties = (await axios.get("https://localhost:7244/counties/list")).data
    this.cities = (await axios.get("https://localhost:7244/cities/list")).data
    this.users = (await axios.get("https://localhost:7244/users/list")).data
  },

  methods: {
    getCityByCar: function(car){
      return this.cities.find(c => c.id === this.users.find(u => u.id === car.sellerId).cityId)
    },

    getCountyByCar: function (car){
      return this.counties.find(c => c.id === this.getCityByCar(car).countyId)
    }
  }
}
</script>

<style scoped>
.carThumbnail {
  display: block;
  cursor: pointer;
  width: 200px;
  height: 150px;
  margin: 0 auto 20px;
  background-position: center center;
  background-size: contain;
}
</style>