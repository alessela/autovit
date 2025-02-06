import Vue from 'vue'
import VueRouter from 'vue-router'
import LoginView from '../views/account/LoginView.vue'
import HomeView from '../views/HomeView.vue'
import Register from '../views/account/Register.vue'
import AdminView from '../views/admin/AdminView.vue'
import BrandManage from "@/views/admin/BrandManage";
import AccountView from "@/views/account/AccountView";
import ModelManage from "@/views/admin/ModelManage";
import BodyStyleManage from "@/views/admin/BodyStyleManage";
import FuelManage from "@/views/admin/FuelManage";
import TransmissionManage from "@/views/admin/TransmissionManage";
import ColorManage from "@/views/admin/ColorManage";
import CountyManage from "@/views/admin/CountyManage";
import CityManage from "@/views/admin/CityManage";
import SoldCars from "@/views/cars/SoldCars";
import CarView from "@/views/cars/CarView";
import CarManage from "@/views/cars/CarManage";
import CarEdit from "@/views/cars/CarEdit";
import BoughtCars from "@/views/cars/BoughtCars";
import MessagesView from "@/views/account/MessagesView";

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    name: 'login',
    component: LoginView
  },
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/register',
    name: 'register',
    component: Register
  },
  {
    path: '/admin',
    name: 'admin',
    component: AdminView
  },
  {
    path: '/admin/brands',
    name: 'brand manage',
    component: BrandManage
  },
  {
    path: '/account',
    name: 'account',
    component: AccountView
  },
  {
    path: '/admin/models',
    name: 'model manage',
    component: ModelManage
  },
  {
    path: '/admin/body_styles',
    name: 'body style manage',
    component: BodyStyleManage
  },
  {
    path: '/admin/fuels',
    name: 'fuel manage',
    component: FuelManage
  },
  {
    path: '/admin/transmissions',
    name: 'transmission manage',
    component: TransmissionManage,
  },
  {
    path: '/admin/colors',
    name: 'color manage',
    component: ColorManage,
  },
  {
    path: '/admin/counties',
    name: 'county manage',
    component: CountyManage,
  },
  {
    path: '/admin/cities',
    name: 'city manage',
    component: CityManage,
  },
  {
    path: '/cars',
    name: 'car manage',
    component: CarManage,
  },
  {
    path: '/cars/sold',
    name: 'sold cars',
    component: SoldCars,
  },
  {
    path: '/cars/bought',
    name: 'bought cars',
    component: BoughtCars
  },
  {
    path: '/cars/:id',
    name: 'car view',
    component: CarView,
  },
  {
    path: '/cars/:id/edit',
    name: 'car edit',
    component: CarEdit
  },
  {
    path: '/messages',
    name: 'messages',
    component: MessagesView
  }

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
