<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Culori
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza culoare</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="colors"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza culoare"
                        outlined
                        dense
                        v-on:input="selectColor"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="selColorCopy=selColor"
            > Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Culoare selectata</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="selColorCopy.name"
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
                @click="updateColor"
            >Editeaza
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteColor"
            >Sterge
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Creeaza culoare</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="newColor.name"
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
                @click="createColor"
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
  name: "ColorManage",
  data(){
    return{
      colors: [],
      selColor: null,
      selColorCopy: {},
      newColor: {},
    }
  },

  async created(){
    this.colors = (await axios.get("https://localhost:7244/colors/list")).data;
  },

  methods:{
    selectColor(e){
      this.selColor = e
    },

    async createColor(){
      await axios.post('https://localhost:7244/colors', this.newColor)
      this.colors = (await axios.get("https://localhost:7244/colors/list")).data;
      alert('Culoare adaugata cu succes')
    },

    async updateColor(){
      try{
        await axios.put('https://localhost:7244/colors', this.selColorCopy);
        this.colors = (await axios.get("https://localhost:7244/colors/list")).data;
        alert('Culoare modificata cu succes!')
      }catch (e) {
        alert('Nu ati selectat o culoare!')
      }
    },

    async deleteColor(){
      try{
        await axios.delete('https://localhost:7244/colors/'+this.selColor.id)
        this.colors = (await axios.get("https://localhost:7244/colors/list")).data;
        alert('Culoare stearsa')
      }catch (e) {
        alert('Nu ati selectat o culoare!')
      }
    }
  }
}
</script>

<style scoped>

</style>