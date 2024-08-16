<template>
  <div>
    <h1>Product List
      <el-button :icon="Edit" round type="primary" @click="routeToAddProduct">Add</el-button>
    </h1>

    <ProductList/>
  </div>
</template>
<script lang="ts" setup>
import {Edit} from '@element-plus/icons-vue'
import ProductList from '../components/ProductList.vue'
import {useRouter} from "vue-router";

const router = useRouter()

function routeToAddProduct() {
  router.push({name: 'AddProduct'})
}
</script>