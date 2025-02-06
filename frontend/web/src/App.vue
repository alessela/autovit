<template>
  <v-app>
    <v-app-bar
      app
      color="brown"
      dark
    >
      <div class="d-flex align-center">
        <a href="/">
          <v-img
              alt="Autovit Logo Logo"
              class="shrink mr-2"
              contain
              src="data:image/png;base64,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"
              transition="scale-transition"
              width="200"
          />
        </a>
      </div>

      <v-spacer></v-spacer>
      <div v-if="currentUser != null">
        <v-text>
          Bine ai venit, <b>{{ currentUser.firstName}} {{ currentUser.lastName}}</b>!
        </v-text>
        <v-btn v-if="!$route.path.startsWith('/cars')"
               text
               rounded
               @click="$router.push('/cars')"
        >Gestionare vehicule</v-btn>
        <v-btn v-if="!$route.path.startsWith('/account')"
            text
            rounded
            @click="$router.push('/account')"
        > Detalii cont
        </v-btn>
        <v-btn v-if="!$route.path.startsWith('/messages')"
               text
               rounded
               @click="$router.push('/messages')"
        > Mesaje
        </v-btn>
        <v-btn v-if="currentUser.isAdmin && !$route.path.startsWith('/admin')"
            text
            rounded
            @click="$router.push('/admin')"
        >
          Administrare site
        </v-btn>
        <v-btn
            text
            rounded
            @click="logout"
        >
          Logout
        </v-btn>
      </div>
      <div v-else-if="$route.path !== '/login' && $route.path !== '/register'">
        <v-btn
            text
            rounded
            @click="$router.push('/login')"
        >
          Login
        </v-btn>

        <v-btn
            text
            rounded
            @click="$router.push('/register')"
        >
          Sign up
        </v-btn>
      </div>
    </v-app-bar>
    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>

import axios from "axios";

export default {
  name: 'App',

  data: () => ({
    currentUser: null
  }),

  async created(){
    try{
      this.currentUser = (await axios.get("https://localhost:7244/users/"
          + window.sessionStorage.getItem("userId"))).data;
    }
    catch(e){

    }
  },

  methods: {
    async logout(){
      window.sessionStorage.setItem("userId", null)
      window.location.href = '/login'
    },

  }
};
</script>

<style>
.main-bg {
  background-image: url("https://thumbs.gfycat.com/HeartyInsistentAnglerfish-size_restricted.gif");
  background-size: cover;
  width: 100%;
  height: 100%;
}

.manage-bg {
  background-color: #ff9933;
  background-size: cover;
  width:100%;
  height:100%;
}

.admin-bg {
  background-image: url("https://wallpaperaccess.com/full/3723585.jpg");
  background-size: cover;
  width:100%;
  height:100%;
}

.home-bg {
  background-color: rgb(255, 255, 204);
  background-size: cover;
  width:100%;
  height: 100%;
}
</style>
