<template>
  <div>
    <h1>Mail List
      <el-button :icon="Edit" round type="primary" @click="routeToAddSubscriptions">Add</el-button>
    </h1>
    <MailList/>
  </div>
</template>
<script lang="ts" setup>
import MailList from '../components/SubscriptionList.vue'
import {Edit} from '@element-plus/icons-vue'
import {useRouter} from "vue-router";

const router = useRouter()

function routeToAddSubscriptions() {
  router.push({name: 'AddSubscription'})
}
</script>