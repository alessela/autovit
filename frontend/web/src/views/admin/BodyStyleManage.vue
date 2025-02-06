<template>
  <div class="manage-bg">
    <h1 style="color:brown" align="center">
      Tipuri de caroserie
    </h1>
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Selecteaza tipul de caroserie</h3>
          <v-form class="ml-6 mr-6">
            <v-combobox rounded
                        background-color=white
                        :items="bodyStyles"
                        :item-text="(o) => (o)['name']"
                        label="Selecteaza tipul de caroserie"
                        outlined
                        dense
                        v-on:input="selectBodyStyle"
            ></v-combobox>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                :style="{color:'brown'}"
                rounded
                @click="selBodyStyleCopy=selBodyStyle"
            > Selecteaza
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Tipul de caroserie selectat</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="selBodyStyleCopy.name"
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
                @click="updateBodyStyle"
            >Editeaza
            </v-btn>
            <v-btn
                class="ml-6 mr-6"
                color="white"
                rounded
                :style="{color:'brown'}"
                @click="deleteBodyStyle"
            >Sterge
            </v-btn>
          </v-form>
        </v-col>
        <v-col align="center" justify="center">
          <h3 :style="{color: 'brown'}">Creeaza tip de caroserie</h3>
          <v-form class="ml-6 mr-6">
            <v-text-field
                v-model="newBodyStyle.name"
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
                @click="createBodyStyle"
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
  name: "BodyStyleManage",
  data() {
    return {
      bodyStyles: [],
      selBodyStyle: null,
      selBodyStyleCopy: {},
      newBodyStyle: {},
    }
  },

  async created() {
    this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data;
  },

  methods: {
    selectBodyStyle(e) {
      this.selBodyStyle = e
    },

    async createBodyStyle() {
      await axios.post("https://localhost:7244/body_styles", this.newBodyStyle);
      this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data;
      alert('Tip caroserie adaugat cu succes')
    },

    async updateBodyStyle() {
      try {
        await axios.put("https://localhost:7244/body_styles", this.selBodyStyleCopy);
        this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data;
        alert('Tip caroserie modificat cu succes')
      } catch (e) {
        alert("Nu ati selectat un tip caroserie!")
      }
    },

    async deleteBodyStyle() {
      try {
        await axios.delete("https://localhost:7244/body_styles/" + this.selBodyStyle.id);
        this.bodyStyles = (await axios.get("https://localhost:7244/body_styles/list")).data;
        alert("Tip caroserie sters")
      } catch (e) {
        alert("Nu ati selectat un tip caroserie!")
      }
    }
  }
}
</script>
<style>

</style>