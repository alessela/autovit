<template>
  <div class ="manage-bg">
    <h1 style ="color:brown" align="center">
      Modele
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza model</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="brands"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza marca"
                        outlined
                        dense
                        @change="selectBrand"
            ></v-combobox>
            <v-combobox rounded
                        background-color=white
                        :items="models"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza model"
                        outlined
                        dense
                        v-on:input="selectModel"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="copyModel"
            >Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Model selectat</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox
                @change="renderKey=1-renderKey"
                :key="renderKey"
                v-model="selBrand"
                label="Marca"
                background-color="white"
                :items="brands"
                :item-text="(o) => (o)['name']"
                outlined
                dense
                rounded
                required
            ></v-combobox>
            <v-text-field v-model="selModelCopy.name"
                          label="Model"
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
                   @click="updateModel"
            >Editeaza</v-btn>
            <v-btn class="ml-6 mr-6"
                   color="white"
                   rounded
                   :style="{color:'brown'}"
                   @click="deleteModel"
            >Sterge</v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color:'brown'}">Creeaza model</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox
                @change="renderKey2=1-renderKey2"
                :key="renderKey2"
                v-model="newBrand"
                label="Marca"
                background-color="white"
                :items="brands"
                :item-text="(o) => (o)['name']"
                outlined
                dense
                rounded
                required
            ></v-combobox>
            <v-text-field v-model="newModel.name"
                          label="Model"
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
                   @click="createModel"
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
  name: "ModelManage",
  data(){
    return{
      brands: [],
      models: [],
      selModel: null,
      selModelCopy: {},
      newModel: {},
      selBrand: null,
      newBrand: null,
      renderKey: 0,
      renderKey2: 0,
    }
  },

  async created(){
    this.brands = (await axios.get("https://localhost:7244/brands/list")).data;
  },

  methods:{
    async selectBrand(e){
      this.models = (await axios.get("https://localhost:7244/models/brand/" + e.id)).data
    },

    selectModel(e){
      this.selModel = e
    },

    async copyModel(){
      try{
        this.selModelCopy=this.selModel
        this.selBrand = (await axios.get("https://localhost:7244/brands/" + this.selModel.brandId)).data
        this.renderKey = 1 - this.renderKey
      }catch (e) {
        alert('Nu ati selectat un model!')
      }

    },

    async updateModel(){
      try{
        this.selModelCopy.brandId = this.selBrand.id
        await axios.put("https://localhost:7244/models", this.selModelCopy)
        alert("Model modificat cu succes")
      }catch (e) {
        alert("Nu ati selectat un model!")
      }
    },

    async deleteModel(){
      try{
        await axios.delete('https://localhost:7244/models/'+this.selModelCopy.id)
        this.models = (await axios.get('https://localhost:7244/models/brand/' + this.selModelCopy.brandId)).data
        alert("Model sters cu succes")
      }catch (e) {
        alert('Nu ati selectat un model!')
      }
    },

    async createModel(){
      try{
        this.newModel.brandId = this.newBrand.id
        await axios.post('https://localhost:7244/models', this.newModel)
        alert('Model creat cu succes')
      }catch (e) {
        alert('Nu ati selectat o marca')
      }

    }

  }
}
</script>

<style scoped>

</style>