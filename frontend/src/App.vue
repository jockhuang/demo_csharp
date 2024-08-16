<script setup>
import {RouterView} from 'vue-router'
import Header from './components/DemoHeader.vue'
import Footer from './components/DemoFooter.vue'
</script>

<template>
  <div>
    <Header/>
    <el-main>
      <RouterView/>
    </el-main>
    <Footer/>

  </div>
</template>

<style scoped>
.body {
  margin: 10 auto 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}


</style>
