import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../pages/Home.vue'
import Students from '../pages/Students.vue'
import StudentForm from '../pages/StudentForm.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },

  {
    path: '/students',
    name: 'Students',
    component: Students
  },
  {
    path: '/students/create',
    name: 'StudentCreate',
    component: StudentForm
  },
  {
    path: '/students/edit/:id',
    name: 'StudentEdit',
    component: StudentForm
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
