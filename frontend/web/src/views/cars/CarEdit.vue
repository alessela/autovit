<template>
<div class="manage-bg">
  <h1 style="color:brown" align="center">Editare masina</h1>
  <v-container fill-height>
    <v-row>
      <v-col align="center" justify="center">
        <v-form class="ml-6 mr-6">
          <v-row>
            <v-col></v-col>
            <v-col>
              <v-text-field v-model="currentCar.name"
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
              <v-combobox v-model="brand"
                          :key="k1"
                          rounded
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
              <v-combobox :key="k2"
                          v-model="model"
                          :items="models"
                          :item-text="(o) => (o)['name']"
                          label="Model"
                          background-color="white"
                          outlined
                          dense
                          rounded
                          required
                          @change="selectModel"
              ></v-combobox>
            </v-col>
            <v-col></v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col></v-col>
            <v-col>
              <v-combobox :key="k3"
                          v-model="bodyStyle"
                          rounded
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
              <v-text-field v-model="currentCar.price"
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
              <v-text-field v-model="currentCar.year"
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
              <v-text-field v-model="currentCar.mileage"
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
              <v-combobox :key="k4"
                          v-model="fuel"
                          rounded
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
              <v-combobox :key="k5"
                          v-model="transmission"
                          rounded
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
              <v-text-field v-model="currentCar.engine"
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
              <v-text-field v-model="currentCar.power"
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
              <v-combobox :key="k6"
                          v-model="color"
                          rounded
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
              <v-checkbox v-model="currentCar.rhd"
                          label="Volan pe dreapta"
              ></v-checkbox>
            </v-col>
            <v-col>
              <v-checkbox v-model="currentCar.new"
                          label="Nou"
              ></v-checkbox>
            </v-col>
            <v-col></v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-textarea v-model="currentCar.description"
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
                     @click="editCar"
              >Editeaza masina</v-btn>
            </v-col>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     rounded
                     :style="{color:'brown'}"
                     @click="deleteCar"
              >Sterge masina</v-btn>
            </v-col>
          </v-row>
        </v-form>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <h2 style="color:brown">Gestionare istoric masina</h2>
      </v-col>
    </v-row>
    <v-row>
      <v-col align="center" justify="center">
        <h3 :style="{color: 'brown'}">Istoric</h3>
        <v-list rounded outlined dense>
          <v-list-item-group
              color="primary">
            <v-list-item v-for="event in events" @click="selectEvent(event)">
              <v-list-item-content>
                <v-list-item-title> {{ event.name}} -- {{ getMonthByDateString(event.date)}}
                {{ getYearByDateString(event.date)}}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-col>
      <v-col align="center" justify="center">
        <h3 :style="{color: 'brown'}">Eveniment selectat</h3>
        <v-form class="ml-6 mr-6">
          <v-text-field
              v-model="selectedEvent.name"
              label="Nume"
              background-color="white"
              outlined
              dense
              rounded
              required
          ></v-text-field>
          <v-date-picker
              v-model="date"
              type="month"
          ></v-date-picker>
          <v-btn class="ml-6 mr-6"
                 color="white"
                 rounded
                 :style="{color:'brown'}"
                 @click="updateEvent"
          >Modifica
          </v-btn>
          <v-btn class="ml-6 mr-6"
                 color="white"
                 rounded
                 :style="{color:'brown'}"
                 @click="deleteEvent"
          >Sterge
          </v-btn>
        </v-form>
      </v-col>
      <v-col align="center" justify="center">
        <h3 :style="{color: 'brown'}">Adauga eveniment</h3>
        <v-form class="ml-6 mr-6">
          <v-text-field
              v-model="newEvent.name"
              label="Nume"
              background-color="white"
              outlined
              dense
              rounded
              required
          ></v-text-field>
          <v-date-picker
              v-model="newDate"
              type="month"
          ></v-date-picker>
          <v-btn class="ml-6 mr-6"
                 color="white"
                 rounded
                 :style="{color:'brown'}"
                 @click="createEvent"
          >Creeaza
          </v-btn>
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
        >Revizualizare masina
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</div>
</template>

<script>
import axios from "axios";

export default {
  name: "CarEdit",

  data(){
    return {
      currentCar: {},
      brands: [],
      brand: null,
      k1: 0,
      models: [],
      model: null,
      k2: 0,
      bodyStyles: [],
      bodyStyle: null,
      k3: 0,
      fuels: [],
      fuel: null,
      k4: 0,
      transmissions: [],
      transmission: null,
      k5: 0,
      colors: [],
      color: null,
      k6: 0,
      filePreview: null,
      selectedEvent: {},
      events: [],
      newEvent: {},
      date: null,
      newDate: null,
      months: ['ianuarie', 'februarie', 'martie', 'aprilie', 'mai', 'iunie', 'iulie', 'august', 'septembrie',
            'octombrie', 'noiembrie', 'decembrie']
    }
  },

  async created(){
    const split = this.$route.path.split('/')
    this.currentCar = (await axios.get('https://localhost:7244/cars/'+split[split.length-2])).data
    this.brands = (await axios.get('https://localhost:7244/brands/list')).data
    this.model = (await axios.get('https://localhost:7244/models/'+this.currentCar.modelId)).data
    this.brand = (await axios.get('https://localhost:7244/brands/'+this.model.brandId)).data
    this.bodyStyles = (await axios.get('https://localhost:7244/body_styles/list')).data
    this.bodyStyle = (await axios.get('https://localhost:7244/body_styles/'+this.currentCar.bodyStyleId)).data
    this.fuels = (await axios.get('https://localhost:7244/fuels/list')).data
    this.fuel = (await axios.get('https://localhost:7244/fuels/'+this.currentCar.fuelId)).data
    this.transmissions = (await axios.get('https://localhost:7244/transmissions/list')).data
    this.transmission = (await axios.get('https://localhost:7244/transmissions/'+this.currentCar.transmissionId)).data
    this.colors = (await axios.get('https://localhost:7244/colors/list')).data
    this.color = (await axios.get('https://localhost:7244/colors/'+this.currentCar.colorId)).data
    this.filePreview = this.currentCar.image
    this.events = (await axios.get('https://localhost:7244/car_events/car/'+this.currentCar.id)).data
  },

  methods: {
    async selectBrand(e){
      this.models = (await axios.get("https://localhost:7244/models/brand/" + e.id)).data
      this.brand = e
      this.k1 = 1 - this.k1
    },

    selectModel(e){
      this.currentCar.modelId = e.id
      this.k2 = 1-this.k2
    },

    selectBodyStyle(e){
      this.currentCar.bodyStyleId = e.id
      this.k3 = 1-this.k3
    },

    selectFuel(e){
      this.currentCar.fuelId = e.id
      this.k4 = 1-this.k4
    },

    selectTransmission(e){
      this.currentCar.transmissionId = e.id
      this.k5 = 1-this.k5
    },

    selectColor(e){
      this.currentCar.colorId = e.id
      this.k6 = 1-this.k6
    },

    selectImgFile () {
      let imgFile = this.$refs.fileInput.files
      if (imgFile && imgFile[0]) {
        let reader = new FileReader
        reader.onload = e => {
          this.filePreview = e.target.result
          this.currentCar.image = e.target.result
        }
        reader.readAsDataURL(imgFile[0])
      }
    },

    async editCar(){
      await axios.put('https://localhost:7244/cars/', this.currentCar)
      alert('Ati editat masina cu succes!')
      this.$router.go(0)
    },

    async deleteCar() {
      await axios.delete('https://localhost:7244/cars/', this.currentCar.id)
      await this.$router.push('/cars')
    },

    async createEvent(){
      this.newEvent.carId = this.currentCar.id
      this.newEvent.date = new Date(this.newDate)
      await axios.post('https://localhost:7244/car_events', this.newEvent)
      alert('Eveniment adaugat cu succes!')
      this.$router.go(0)
    },

    async updateEvent(){
      this.selectedEvent.date = new Date(this.date)
      await axios.put('https://localhost:7244/car_events', this.selectedEvent)
      alert('Eveniment modificat cu succes!')
    },

    async deleteEvent(){
      await axios.delete('https://localhost:7244/car_events/' + this.selectedEvent.id)
      alert('Eveniment sters cu succes!')
      this.$router.go(0)
    },

    selectEvent(e){
      this.selectedEvent = e
      this.date = this.getYearByDateString(e.date) + '-' + this.getMonthIndex(e.date)
    },

    getMonthByDateString(date){
      return this.months[new Date(date).getMonth()]
    },

    getYearByDateString(date){
      return new Date(date).getFullYear()
    },

    getMonthIndex(date){
      return new Date(date).getMonth() + 1;
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
</style>