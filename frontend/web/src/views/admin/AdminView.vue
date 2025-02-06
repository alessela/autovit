<template>
  <div class="admin-bg">
    <v-container fill-height>
      <v-row>
        <v-col align="center" justify="center">
          <h1 style="color:white">Administrare site</h1>
          <v-row>
            <v-col>
              <v-btn
                  class="ml-6 mr-6"
                  color="white"
                  :style="{color:'brown'}"
                  rounded
                  @click="$router.push('admin/brands')"
              > Marci
              </v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn
                  class="ml-6 mr-6"
                  color="white"
                  :style="{color:'brown'}"
                  rounded
                  @click="$router.push('admin/models')"
              > Modele
              </v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/body_styles')"
              >Tipuri caroserie</v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/fuels')"
              >Combustibili
              </v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/transmissions')"
              >Transmisii
              </v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/colors')"
              >Culori</v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/counties')"
              >Judete</v-btn>
            </v-col>
          </v-row>
          <v-spacer></v-spacer>
          <v-row>
            <v-col>
              <v-btn class="ml-6 mr-6"
                     color="white"
                     :style="{color:'brown'}"
                     rounded
                     @click="$router.push('admin/cities')"
              >Orase</v-btn>
            </v-col>
          </v-row>
        </v-col>
        <v-col>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  name: "AdminView",

}
</script>
<style>

</style>
