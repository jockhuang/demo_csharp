<template>
<el-menu :router="true" :default-active="activeLink" class="el-menu-demo" mode="horizontal">
    <el-menu-item >
      <img
        style="width: 50px"
        src="@/assets/logo.svg"
        alt="Demo logo"
      />
    </el-menu-item>
    <div class="flex-grow" />
    <el-menu-item v-for="rule in menuRoutes" :index="rule.path" :key="rule.path">
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
            this.activeLink =  window.location.pathname;
        },
        data() {
            return {
                activeLink: null,
                menuRoutes: [
                    {name:'Product',path:'/'},
                    {name:'MailList',path:'mailList'}
                ],
            };
        },
    };
</script>