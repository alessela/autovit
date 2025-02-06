<template>
 <div class="manage-bg">
   <h1 style="color:brown" align="center">
     Transmisii
   </h1>
   <v-container fill-height>
     <v-row>
       <v-col align="center" justify="center">
         <h3 :style="{color: 'brown'}">Selecteaza cutie de viteze</h3>
         <v-form class="ml-6 mr-6">
           <v-combobox rounded
                       background-color=white
                       :items="transmissions"
                       :item-text="(o) => (o)['name']"
                       label="Selecteaza cutie de viteze"
                       outlined
                       dense
                       v-on:input="selectTransmission"
           ></v-combobox>
           <v-btn
               class="ml-6 mr-6"
               color="white"
               :style="{color:'brown'}"
               rounded
               @click="selTransmissionCopy=selTransmission"
           > Selecteaza
           </v-btn>
         </v-form>
       </v-col>
       <v-col align="center" justify="center">
         <h3 :style="{color: 'brown'}">Cutie de viteza selectata</h3>
         <v-form class="ml-6 mr-6">
           <v-text-field
               v-model="selTransmissionCopy.name"
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
               @click="updateTransmission"
           >Editeaza
           </v-btn>
           <v-btn
               class="ml-6 mr-6"
               color="white"
               rounded
               :style="{color:'brown'}"
               @click="deleteTransmission"
           >Sterge
           </v-btn>
         </v-form>
       </v-col>
       <v-col align="center" justify="center">
         <h3 :style="{color: 'brown'}">Creeaza cutie de viteze</h3>
         <v-form class="ml-6 mr-6">
           <v-text-field
               v-model="newTransmission.name"
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
               @click="createTransmission"
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
  name: "TransmissionManage",
  data(){
    return{
      transmissions: [],
      selTransmission: null,
      selTransmissionCopy: {},
      newTransmission: {},
    }
  },

  async created(){
    this.transmissions = (await axios.get("https://localhost:7244/transmissions/list")).data;
  },
  methods:{
    selectTransmission(e){
      this.selTransmission = e
    },

    async createTransmission(){
      await axios.post('https://localhost:7244/transmissions', this.newTransmission)
      this.transmissions = (await axios.get('https://localhost:7244/transmissions/list')).data
      alert('Transmisie adaugata cu succes')
    },

    async updateTransmission(){
      try{
        await axios.put('https://localhost:7244/transmissions', this.selTransmissionCopy);
        this.transmissions = (await axios.get('https://localhost:7244/transmissions/list')).data
        alert('Transmisie modificata cu succes!')
      }catch (e) {
        alert('Nu ati selectat o transmisie!')
      }
    },

    async deleteTransmission(){
      try{
        await axios.delete('https://localhost:7244/transmissions/'+this.selTransmission.id)
        this.transmissions = (await axios.get('https://localhost:7244/transmissions/list')).data
        alert('Transmisie stearsa')
      }catch (e) {
        alert('Nu ati selectat o transmisie!')
      }
    }
  }
}

</script>

<style scoped>

</style>