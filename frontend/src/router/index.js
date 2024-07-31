import { createRouter, createWebHistory } from 'vue-router'
import MailListView from '../views/MailListView.vue'
import ProductListView from '../views/ProductListView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Product',
      component: ProductListView
    },
    {
      path: '/mailList', 
      name: 'MailList',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: MailListView
    }
  ]
})

export default router
