<template>
  <div class="home-bg">
    <h1 style="color:brown" align="center">Adauga masina de vanzare</h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <v-form class="ml-6 mr-6">
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-text-field v-model="newCar.name"
                              rounded
                              background-color="white"
                              label="Nume"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            background-color=white
                            :items="brands"
                            :item-text="(o) => (o)['name']"
                            label="Marca"
                            outlined
                            dense
                            @change="selectBrand"
                            required
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            :key="k1"
                            v-model="model"
                            background-color=white
                            :items="models"
                            :item-text="(o) => (o)['name']"
                            label="Model"
                            @change="selectModel"
                            outlined
                            dense
                            required
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            background-color=white
                            :items="bodyStyles"
                            :item-text="(o) => (o)['name']"
                            label="Tip caroserie"
                            @change="selectBodyStyle"
                            outlined
                            dense
                            required
                ></v-combobox>
              </v-col>
              <v-col>
                <v-text-field v-model="newCar.price"
                              type="number"
                              rounded
                              background-color="white"
                              label="Pret (euro)"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-text-field v-model="newCar.year"
                              type="number"
                              rounded
                              background-color="white"
                              label="An de fabricatie"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field v-model="newCar.mileage"
                              type="number"
                              rounded
                              background-color="white"
                              label="Rulaj km"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            background-color=white
                            :items="fuels"
                            :item-text="(o) => (o)['name']"
                            label="Combustibil"
                            @change="selectFuel"
                            outlined
                            dense
                            required
                ></v-combobox>
              </v-col>
              <v-col>
                <v-combobox rounded
                            background-color=white
                            :items="transmissions"
                            :item-text="(o) => (o)['name']"
                            label="Cutie de viteze"
                            @change="selectTransmission"
                            outlined
                            dense
                            required
                ></v-combobox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-text-field v-model="newCar.engine"
                              type="number"
                              rounded
                              background-color="white"
                              label="Capacitate motor (cm3)"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field v-model="newCar.power"
                              type="number"
                              rounded
                              background-color="white"
                              label="Putere (cp)"
                              outlined
                              dense
                              required
                ></v-text-field>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col></v-col>
              <v-col>
                <v-combobox rounded
                            background-color=white
                            :items="colors"
                            :item-text="(o) => (o)['name']"
                            label="Culoare"
                            @change="selectColor"
                            outlined
                            dense
                            required
                ></v-combobox>
              </v-col>
              <v-col>
                <v-checkbox v-model="newCar.rhd"
                            label="Volan pe dreapta"
                ></v-checkbox>
              </v-col>
              <v-col>
                <v-checkbox v-model="newCar.new"
                            label="Nou"
                ></v-checkbox>
              </v-col>
              <v-col></v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col>
                <v-textarea v-model="newCar.description"
                            label="Descriere"
                            rounded
                            background-color="white"
                            outlined
                            dense
                            required
                ></v-textarea>
              </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col>
                <div
                    class="previewBlock"
                    :style="{ 'background-image': `url(${filePreview})` }">
                </div>
                <div>
                  <input
                      ref="fileInput"
                      type="file"
                      accept="image/*"
                      @input="selectImgFile">
                </div>
              </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col>
                <v-btn class="ml-6 mr-6"
                       color="white"
                       rounded
                       :style="{color:'brown'}"
                       @click="addCar"
                >Adauga masina</v-btn>
              </v-col>
            </v-row>
          </v-form>
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
      <v-row>
        <v-col>
          <h1 :style="{color: 'brown'}">Masini de vanzare</h1>
        </v-col>
      </v-row>
      <v-spacer></v-spacer>
      <div :key="k2">
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
  name: "SoldCars",
  data() {
    return {
      currentUser: null,
      brands: [],
      models: [],
      bodyStyles: [],
      fuels: [],
      transmissions: [],
      colors: [],
      counties: [],
      cities: [],
      cars: [],
      brand: null,
      model: null,
      k1: 0,
      newCar: {},
      filePreview: {},
      k2: 0,
    };
  },

  async created(){
    this.currentUser = (await axios.get("https://localhost:7244/users/"
        + window.sessionStorage.getItem("userId"))).data;
    this.brands = (await axios.get("https://localhost:7244/brands/list")).data
    this.users = (await axios.get("https://localhost:7244/users/list")).data
    this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data
    this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data
    this.transmissions = (await axios.get("https://localhost:7244/transmissions/list")).data
    this.colors = (await axios.get("https://localhost:7244/colors/list")).data
    this.counties = (await axios.get("https://localhost:7244/counties/list")).data
    this.cities = (await axios.get("https://localhost:7244/cities/list")).data
    this.filePreview = 'https://image.shutterstock.com/image-vector/insert-picture-photo-gallery-icon-260nw-1758342257.jpg'
    this.newCar.sellerId = this.currentUser.id;
    this.cars = (await axios.get('https://localhost:7244/cars/seller/' + this.currentUser.id)).data
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
      if (e != null) this.newCar.modelId = e.id
      this.k1=1-this.k1
    },

    selectBodyStyle(e){
      this.newCar.bodyStyleId = e.id
    },

    selectFuel(e){
      this.newCar.fuelId = e.id
    },

    selectTransmission(e){
      this.newCar.transmissionId = e.id
    },

    selectColor(e){
      this.newCar.colorId = e.id
    },

    selectImgFile () {
      let imgFile = this.$refs.fileInput.files
      if (imgFile && imgFile[0]) {
        let reader = new FileReader
        reader.onload = e => {
          this.filePreview = e.target.result
          this.newCar.image = e.target.result
        }
        reader.readAsDataURL(imgFile[0])
      }
    },

    async addCar(){
      await axios.post("https://localhost:7244/cars", this.newCar)
      alert('Masina adaugata cu succes')
      this.k2=1-this.k2
    },

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
.previewBlock {
  display: block;
  cursor: pointer;
  width: 300px;
  height: 280px;
  margin: 0 auto 20px;
  background-position: center center;
  background-size: cover;
}

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