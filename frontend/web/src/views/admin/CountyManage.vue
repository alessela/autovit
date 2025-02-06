<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Judete
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza judet</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="counties"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza judet"
                        outlined
                        dense
                        v-on:input="selectCounty"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="selCountyCopy=selCounty"
            > Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Judet selectat</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="selCountyCopy.name"
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
                @click="updateCounty"
            >Editeaza
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteCounty"
            >Sterge
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Creeaza judet</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="newCounty.name"
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
                @click="createCounty"
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
  name: "CountyManage",
  data(){
    return{
      counties: [],
      selCounty: null,
      selCountyCopy: {},
      newCounty: {},
    }
  },

  async created(){
    this.counties = (await axios.get("https://localhost:7244/counties/list")).data;
  },

  methods:{
    selectCounty(e){
      this.selCounty = e
    },

    async createCounty(){
      await axios.post('https://localhost:7244/counties', this.newCounty)
      this.counties = (await axios.get("https://localhost:7244/counties/list")).data;
      alert('Judet adaugat cu succes')
    },

    async updateCounty(){
      try{
        await axios.put('https://localhost:7244/counties', this.selCountyCopy);
        this.counties = (await axios.get("https://localhost:7244/counties/list")).data;
        alert('Judet modificat cu succes!')
      }catch (e) {
        alert('Nu ati selectat un judet!')
      }
    },

    async deleteCounty(){
      try{
        await axios.delete('https://localhost:7244/counties/'+this.selCounty.id)
        this.counties = (await axios.get("https://localhost:7244/counties/list")).data;
        alert('Judet sters')
      }catch (e) {
        alert('Nu ati selectat un judet!')
      }
    }
  }
}
</script>

<style scoped>

</style>