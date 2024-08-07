<template>
    <div>
      <el-page-header :icon="ArrowLeft" @back="$router.back()">
      <template #content>
        <span class="text-large font-600 mr-3"> Add Subscription </span>
      </template>
    </el-page-header>
    <br>
    <el-card style="max-width: 600px">
      <el-form :model="subscription" ref="ruleFormRef" label-width="auto" style="max-width: 600px">
        <el-form-item label="Email" prop="email" :rules="rules.email">
          <el-input v-model="subscription.email" />
        </el-form-item>
        <el-form-item label="Description" prop="description" >
          <el-input v-model="subscription.description" type="textarea" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm(ruleFormRef)">Add</el-button>
          <el-button @click="$router.push({name:'Subscriptions'})">Cancel</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    </div>
  </template>

<script lang="ts" setup>
import axios from 'axios';
import { ElMessage } from 'element-plus'
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'


import type { FormInstance, FormRules } from 'element-plus'
import { ArrowLeft } from '@element-plus/icons-vue'

const route = useRoute()
const router = useRouter()
const slug = computed<string>(() => route.params.slug as string)

interface SubscriptionForm {
  email: string
  description: string
  
}
const ruleFormRef = ref<FormInstance>()
const subscription = reactive<SubscriptionForm>({
  email: '',
  description: '',
  
})

const rules =  reactive<FormRules<SubscriptionForm>>({
  email: [
    { required: true, message: 'Please input the email', trigger: 'blur' },
    { min: 3, max: 255, message: 'Length should be 3 to 25', trigger: 'blur' },
  ],
  
})

const submitForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) return
  await formEl.validate((valid, fields) => {
    if (valid) {
      console.log('submit!')
      
    axios.post('http://localhost/api/MailList/AddSubscription',subscription)
    .then(response => {
        console.log(response.data);
        const data = response.data;
        ElMessage({
        message: 'Congrats, this email has been added!',
        type: 'success',
        })
    })
    .catch(error => {
        console.error(error);
        if(error.response.data.message){
        ElMessage.error(error.response.data.message)
        }else{
        ElMessage.error(error.message)
        }
        
    });
    
    router.push({name:'Subscriptions'})
      
    } else {
      ElMessage.error("Oops, Please check the input.")
      console.log('error submit!', fields)
    }
  })
}


</script>