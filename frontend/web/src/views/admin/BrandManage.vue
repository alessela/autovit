<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Marci
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza marca</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="brands"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza marca"
                        outlined
                        dense
                        v-on:input="selectBrand"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="selBrandCopy=selBrand"
            > Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Marca selectata</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="selBrandCopy.name"
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
                @click="updateBrand"
            >Editeaza
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteBrand"
            >Sterge
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Creeaza marca</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="newBrand.name"
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
                @click="createBrand"
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
  name: "BrandManage",
  data(){
    return{
      brands: [],
      selBrand: null,
      selBrandCopy: {},
      newBrand: {},
    }
  },

  async created(){
    this.brands = (await axios.get("https://localhost:7244/brands/list")).data;
  },

  methods:{

    selectBrand(e){
      this.selBrand = e
    },

    async createBrand(){
      await axios.post("https://localhost:7244/brands", this.newBrand);
      this.brands = (await axios.get("https://localhost:7244/brands/list")).data;
      alert('Marca adaugata cu succes!')
    },

    async updateBrand(){
      try{
        await axios.put("https://localhost:7244/brands", this.selBrandCopy);
        this.brands = (await axios.get("https://localhost:7244/brands/list")).data;
        alert("Marca modificata cu succes!")
      }
      catch (e) {
        alert("Nu ati selectat o marca!")
      }
    },

    async deleteBrand(){
      try{
        await axios.delete("https://localhost:7244/brands/" + this.selBrand.id);
        this.brands = (await axios.get("https://localhost:7244/brands/list")).data;
        alert("Marca stearsa")
      }
      catch (e) {
        alert("Nu ati selectat o marca!")
      }
    }
  }
}
</script>
<style>

</style>