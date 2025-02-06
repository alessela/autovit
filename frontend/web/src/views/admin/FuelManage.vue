<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Combustibili
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza combustibil</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="fuels"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza combustibil"
                        outlined
                        dense
                        v-on:input="selectFuel"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="selFuelCopy=selFuel"
            > Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Combustibil selectat</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="selFuelCopy.name"
                label="Nume"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="updateFuel"
            >Editeaza
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteFuel"
            >Sterge
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Creeaza combustibil</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="newFuel.name"
                label="Nume"
                background-color="white"
                outlined
                dense
                rounded
                required
            ></v-text-field>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="createFuel"
            >Creeaza
            </v-btn>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
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
      </v-row>
    </v-container>
  </div>

</template>

<script>
import axios from "axios";

export default {
  name: "FuelManage",
  data(){
    return{
      fuels: [],
      selFuel: null,
      selFuelCopy: {},
      newFuel: {},
    }
  },

  async created(){
    this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data;
  },

  methods:{
    selectFuel(e){
      this.selFuel = e
    },

    async createFuel(){
      await axios.post('https://localhost:7244/fuels', this.newFuel)
      this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data;
      alert('Combustibil adaugat cu succes')
    },

    async updateFuel(){
      try{
        await axios.put('https://localhost:7244/fuels', this.selFuelCopy);
        this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data;
        alert('Combustibil modificat cu succes!')
      }catch (e) {
        alert('Nu ati selectat un combustibil!')
      }
    },

    async deleteFuel(){
      try{
        await axios.delete('https://localhost:7244/fuels/'+this.selFuel.id)
        this.fuels = (await axios.get("https://localhost:7244/fuels/list")).data;
        alert('Combustibil sters')
      }catch (e) {
        alert('Nu ati selectat un combustibil!')
      }
    }

  }
}
</script>

<style scoped>

</style>