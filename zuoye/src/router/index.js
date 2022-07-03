import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('../views/home.vue'),
    children:[
      {
        path: '/',
        name: 'home',
        component: () => import('../views/Menu/show.vue')
      },
      {
        path: '/listadmin',
        name: 'f',
        component: () => import('../views/Admin/listadmin.vue')
      },
      {
        path: '/rolelist',
        name: 'g',
        component: () => import('../views/Role/rolelist.vue')
      },
    ]
  },
  {
    path: '/add',
    name: 'home',
    component: () => import('../views/Menu/add.vue')
  },
  {
    path: '/upd',
    name: 'b',
    component: () => import('../views/Menu/upd.vue')
  },
  {
    path: '/zhu',
    name: 'e',
    component: () => import('../views/Admin/zhu.vue')
  },
  {
    path: '/login',
    name: '登录',
    component: () => import('../views/Admin/Login.vue')
  },
  {
    path: '/tree',
    name: 'h',
    component: () => import('../views/Role/tree.vue')
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = new VueRouter({
  routes
})
let userna = sessionStorage.getItem("userName")??"";
router.beforeEach((to,form,next) =>{
  if(to.name != '登录' && form.name != '登录')
  {
    next({name:'登录'});
  }else{
    next()
  }
})

export default router
