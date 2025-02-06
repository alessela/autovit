<template>
  <div class="main-bg">
    <v-container fill-height>
      <v-row>
      </v-row>
      <v-row>
        <v-col>
        </v-col>
        <v-col align="center" justify="center"
               :style="{
          backgroundColor: 'black',
          opacity: 0.7
        }"
        >
          <h1 style="color:white">Autentifica-te</h1>

          <v-form class="ml-6 mr-6">
            <v-text-field
                class="text-white"
                background-color=rgb(127,127,127)
                v-model="email"
                label="Email"
                rounded
                required
            ></v-text-field>

            <v-text-field
                class="text-white"
                background-color=rgb(127,127,127)
                v-model="password"
                label="Parola"
                type="password"
                rounded
                required
            ></v-text-field>

            <v-btn
                text
                :style="{color:'white'}"
                rounded
                @click="login"
            >
              Login
            </v-btn>
            <v-btn
                text
                :style="{color:'white'}"
                rounded
                @click="$router.push('register')"
            >
              Sign up
            </v-btn>
          </v-form>
        </v-col>
        <v-col>
        </v-col>
      </v-row>
      <v-row>

      </v-row>
    </v-container>
  </div>
</template>

<script>
  import axios from "axios";
  export default {
    name: 'Login',
    data() {
      return {
        email: "",
        password: ""
      }
    },
    methods: {
      encode: function(str){
        return encodeURIComponent(str).replace(/!/g, '%21').replace(/\*/g, '%2A')
            .replace(/\(/g, '%28').replace(/\)/g,'%29').replace(/'/g, '%27');
      },

      async login() {
        try {
          window.sessionStorage.setItem("userId",
              (await axios.post("https://localhost:7244/users/login?email=" + this.encode(this.email) + "&password="
                  + this.encode(this.password), {email: this.email, password: this.password})).data.id);
          window.location.href = '/'
        } catch (e) {
          alert("Credentiale incorecte!");
        }
      }
    }
  }
</script>

<style>
.text-white input {
  color: white !important;
}

</style>