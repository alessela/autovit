<template>
  <div class="home-bg">
    <v-container fill-height>
      <h1 :style="{color: 'brown'}">Cauta masina</h1>
      <v-row>
        <v-col align="center" justify="center">
          <v-form class="ml-6 mr-6">
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="brands"
                            :item-text="(o) => (o)['name']"
                            label="Marca"
                            outlined
                            dense
                            @change="selectBrand"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            :key="k1"
                            v-model="model"
                            background-color=white
                            :items="models"
                            :item-text="(o) => (o)['name']"
                            label="Model"
                            @change="k1=1-k1"
                            outlined
                            dense
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="bodyStyles"
                            :item-text="(o) => (o)['name']"
                            label="Tip caroserie"
                            outlined
                            dense
                            @change="selectBodyStyle"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="fuels"
                            :item-text="(o) => (o)['name']"
                            label="Combustibil"
                            outlined
                            dense
                            @change="selectFuel"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <h4 :style="{color: 'brown'}">Pret (euro)</h4>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            v-model="minPrice"
                            background-color=white
                            :items="prices"
                            label="De la"
                            outlined
                            dense
                            @change="selectMinPrice"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            v-model="maxPrice"
                            background-color=white
                            :items="prices"
                            label="Pana la"
                            outlined
                            dense
                            @change="selectMaxPrice"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <h4 :style="{color: 'brown'}">An de fabricatie</h4>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            v-model="minYear"
                            background-color=white
                            :items="years"
                            label="De la"
                            outlined
                            dense
                            @change="selectMinYear"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            v-model="maxYear"
                            background-color=white
                            :items="years"
                            label="Pana la"
                            outlined
                            dense
                            @change="selectMaxYear"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <h4 :style="{color: 'brown'}">Kilometraj</h4>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="mileages"
                            label="De la"
                            outlined
                            dense
                            @change="selectMinMileage"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="mileages"
                            label="Pana la"
                            outlined
                            dense
                            @change="selectMaxMileage"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="transmissions"
                            :item-text="(o) => (o)['name']"
                            label="Cutie de viteze"
                            outlined
                            dense
                            @change="selectTransmission"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="colors"
                            :item-text="(o) => (o)['name']"
                            label="Culoare"
                            outlined
                            dense
                            @change="selectColor"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <h4 :style="{color: 'brown'}">Capacitate motor (cm3)</h4>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="engines"
                            label="De la"
                            outlined
                            dense
                            @change="selectMinEngine"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="engines"
                            label="Pana la"
                            outlined
                            dense
                            @change="selectMaxEngine"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <h4 :style="{color: 'brown'}">Putere (cp)</h4>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="powers"
                            label="De la"
                            outlined
                            dense
                            @change="selectMinPower"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="powers"
                            label="Pana la"
                            outlined
                            dense
                            @change="selectMaxPower"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="['stanga', 'dreapta']"
                            label="Volan"
                            outlined
                            dense
                            @change="selectRhd"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="['utilizat', 'nou']"
                            label="Stare"
                            outlined
                            dense
                            @change="selectNew"
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            background-color=white
                            :items="counties"
                            :item-text="(o) => (o)['name']"
                            label="Judet"
                            outlined
                            dense
                            @change="selectCounty"
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            clearable
                            :key="k2"
                            v-model="city"
                            background-color=white
                            :items="cities"
                            :item-text="(o) => (o)['name']"
                            label="Oras"
                            @change="k2=1-k2"
                            outlined
                            dense
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row align="center" justify="center">
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="filterCars"
              >Cauta</v-btn>
            </v-row>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <h1 :style="{color: 'brown'}">Rezultate gasite</h1>
        </v-col>
      </v-row>
      <v-spacer></v-spacer>
      <div :key="k3">
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
      </div>
    </v-container>
  </div>
</template>

<script>
  import axios from "axios";
  export default {
    name: 'Home',
    data() {
      return {
        brands: [],
        models: [],
        bodyStyles: [],
        prices: [1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000,
          10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000],
        years: [2022, 2021, 2020, 2019, 2018, 2017, 2016, 2015, 2014, 2013,
          2012, 2011, 2010, 2009, 2008, 2007, 2006, 2005, 2004, 2003, 2002, 2001, 2000],
        mileages: [5000, 10000, 20000, 35000, 50000, 75000, 100000, 125000, 150000, 175000, 200000, 250000],
        fuels: [],
        transmissions: [],
        colors: [],
        engines: [500, 1000, 1500, 2000, 2500, 3000, 4000, 5000],
        powers: [50, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 250, 300, 400, 500],
        counties: [],
        cities: [],
        allcities: [],
        cars: [],
        users: [],
        brand: null,
        model: null,
        k1: 0,
        bodyStyle: null,
        minPrice: null,
        maxPrice: null,
        minYear: null,
        maxYear: null,
        minMileage: null,
        maxMileage: null,
        fuel: null,
        transmission: null,
        color: null,
        minEngine: null,
        maxEngine: null,
        minPower: null,
        maxPower: null,
        rhd: null,
        new: null,
        county: null,
        city: null,
        k2: 0,
        filePreview: {},
        k3: 0,
        soldCars: [],
      }
    },

    async created() {
      try {
        this.users = (await axios.get("https://localhost:7244/users/list")).data
        this.brands = (await axios.get("https://localhost:7244/brands/list")).data
        this.all_models = (await axios.get("https://localhost:7244/models/list")).data
        this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data
        this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data
        this.transmissions = (await axios.get("https://localhost:7244/transmissions/list")).data
        this.colors = (await axios.get("https://localhost:7244/colors/list")).data
        this.counties = (await axios.get("https://localhost:7244/counties/list")).data
        this.users = (await axios.get("https://localhost:7244/users/list")).data
        this.allcities = (await axios.get("https://localhost:7244/cities/list")).data
        this.soldCars = (await axios.get("https://localhost:7244/sold_cars/list")).data
        this.cars = (await axios.get("https://localhost:7244/cars/list")).data
            .filter(c => !this.soldCars.some(sc => sc.carId === c.id))
      }
      catch (e) {

      }
    },
    methods: {
      async selectBrand(e){
        this.brand = e
        if (e != null)
          this.models = (await axios.get("https://localhost:7244/models/brand/" + e.id)).data
        else
          this.models = []
        this.model = null
        this.k1 = 1-this.k1
      },

      selectModel(e){
        this.model = e
        this.k1 = 1-this.k1
      },

      selectBodyStyle(e){
        this.bodyStyle = e
      },

      selectMinPrice(e){
        this.minPrice = e
      },

      selectMaxPrice(e){
        this.maxPrice = e
      },

      selectMinYear(e){
        this.minYear = e
      },

      selectMaxYear(e){
        this.maxYear = e
      },

      selectMinMileage(e){
        this.minMileage = e
      },

      selectMaxMileage(e){
        this.maxMileage = e
      },

      selectFuel(e){
        this.fuel = e
      },

      selectTransmission(e){
        this.transmission = e
      },

      selectColor(e){
        this.color = e
      },

      selectMinEngine(e){
        this.minEngine = e
      },

      selectMaxEngine(e){
        this.maxEngine = e
      },

      selectMinPower(e){
        this.minPower = e
      },

      selectMaxPower(e){
        this.maxPower = e
      },

      selectRhd(e){
        this.rhd = e
      },

      selectNew(e){
        this.new = e
      },

      async selectCounty(e){
        this.county = e
        if (e != null)
          this.cities = (await axios.get("https://localhost:7244/cities/county/" + e.id)).data
        else
          this.cities = []
        this.city = null
        this.k2 = 1-this.k2
      },

      selectCity(e){
        this.city = e
      },

      async filterCars(){
        this.cars = (await axios.get("https://localhost:7244/cars/list")).data
        if (this.model != null) this.cars = this.cars.filter(c => c.modelId === this.model.id)
        else if (this.brand != null) {
          this.cars = this.cars.filter(c => this.all_models.find(m => m.id === c.modelId).brandId === this.brand.id)
        }

        if (this.bodyStyle != null) this.cars = this.cars.filter(c => c.bodyStyleId === this.bodyStyle.id)
        if (this.fuel != null) this.cars = this.cars.filter(c => c.fuelId === this.fuel.id)
        if (this.minPrice != null) this.cars = this.cars.filter( c => c.price >= this.minPrice)
        if (this.maxPrice != null) this.cars = this.cars.filter( c => c.price <= this.maxPrice)
        if (this.minYear != null) this.cars = this.cars.filter( c => c.year >= this.minYear)
        if (this.maxYear != null) this.cars = this.cars.filter( c => c.year <= this.maxYear)
        if (this.minMileage != null) this.cars = this.cars.filter( c => c.mileage >= this.minMileage)
        if (this.maxMileage != null) this.cars = this.cars.filter( c => c.mileage <= this.maxMileage)
        if (this.transmission != null) this.cars = this.cars.filter(c => c.transmissionId === this.transmission.id)
        if (this.color != null) this.cars = this.cars.filter(c => c.colorId === this.color.id)
        if (this.minEngine != null) this.cars = this.cars.filter( c => c.engine >= this.minEngine)
        if (this.maxEngine != null) this.cars = this.cars.filter( c => c.engine <= this.maxEngine)
        if (this.minPower != null) this.cars = this.cars.filter( c => c.power >= this.minPower)
        if (this.maxPower != null) this.cars = this.cars.filter( c => c.power <= this.maxPower)
        if (this.rhd != null ){
          if (this.rhd === 'stanga') this.cars = this.cars.filter ( c => !c.rhd)
          else this.cars = this.cars.filter(c => c.rhd)
        }
        if (this.new != null ){
          if (this.new === 'utilizat') this.cars = this.cars.filter ( c => !c.new)
          else this.cars = this.cars.filter(c => c.new)
        }
        if (this.city != null) this.cars = this.cars
            .filter(c => this.getCityByCar(c).id === this.city.id)
        else if (this.county != null) this.cars = this.cars
            .filter(c => this.getCountyByCar(c) === this.county)
        this.k3 = 1 - this.k3
      },

      getCityByCar: function(car){
        return this.allcities.find(c => c.id === this.users.find(u => u.id === car.sellerId).cityId)
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