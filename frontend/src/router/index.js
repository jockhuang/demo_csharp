import { createRouter, createWebHistory } from 'vue-router'
import MailListView from '../views/MailListView.vue'
import ProductListView from '../views/ProductListView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Product',
      component: ProductListView,
    },
    // {
    //   name: 'product',
    //   path: '/product/:slug',
    //   component: () => import('./views/ProductView.vue'),
    // },
    // {
    //   name: 'edit-product',
    //   path: '/product/:slug/edit',
    //   component: () => import('./views/EditProductView.vue'),
    // },
    {
      name: 'AddProduct',
      path: '/product/create',
      component: () => import('../views/EditProductView.vue'),
    },
    {
      name: 'EditProduct',
      path: '/product/:slug/edit',
      component: () => import('../views/EditProductView.vue'),
    },
    {
      path: '/subscriptions', 
      name: 'Subscriptions',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: MailListView
    },
    {
      name: 'AddSubscription',
      path: '/subscriptions/add',
      component: () => import('../views/EditSubscription.vue'),
    },
  ]
})

export default router
