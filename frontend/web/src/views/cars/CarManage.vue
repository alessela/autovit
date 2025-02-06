<template>
  <div class="admin-bg">
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h1 style="color:white">Gestionare masini</h1>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('cars/sold')"
              >Masini de vanzare</v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('cars/bought')"
              >Masini cumparate</v-btn>
            </v-col>
          </v-row>
        </v-col>
        <v-col></v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  name: "CarManage"
}
</script>

<style scoped>

</style>