<template>
  <el-menu :default-active="activeLink" :router="true" class="el-menu-demo" mode="horizontal">
    <el-menu-item>
      <img
          alt="Demo logo"
          src="@/assets/logo.svg"
          style="width: 50px"
      />
    </el-menu-item>
    <div class="flex-grow"/>
    <el-menu-item v-for="rule in menuRoutes" :key="rule.path" :index="rule.path">
      <i :class="rule.icon"></i>
      {{ rule.name }}
    </el-menu-item>
  </el-menu>
</template>

<script type='text/babel'>
export default {
  mounted: function () {
    console.log("router");
    console.log(this.$route.path);
    this.activeLink = window.location.pathname;
  },
  data() {
    return {
      activeLink: null,
      menuRoutes: [
        {name: 'Home', path: '/'},
        {name: 'Product', path: '/product'},
        {name: 'Subscriptions', path: '/subscriptions'}
      ],
    };
  },
};
</script>