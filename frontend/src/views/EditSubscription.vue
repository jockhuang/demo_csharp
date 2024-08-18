<template>
  <div>
    <el-page-header :icon="ArrowLeft" @back="$router.back()">
      <template #content>
        <span class="text-large font-600 mr-3"> Add Subscription </span>
      </template>
    </el-page-header>
    <br>
    <el-card style="max-width: 600px">
      <el-form ref="ruleFormRef" :model="subscription" label-width="auto" style="max-width: 600px">
        <el-form-item :rules="rules.email" label="Email" prop="email">
          <el-input v-model="subscription.email"/>
        </el-form-item>
        <el-form-item label="Description" prop="description">
          <el-input v-model="subscription.description" type="textarea"/>
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
import {FormInstance, FormRules, ElMessage} from 'element-plus'
import {reactive, ref} from 'vue'
import {useRouter} from 'vue-router'
import api, {Subscription} from "@/common/api"
import {ArrowLeft} from '@element-plus/icons-vue'

const router = useRouter()


const ruleFormRef = ref<FormInstance>()
const subscription = reactive<Subscription>({
  email: '',
  description: '',

})

const rules = reactive<FormRules<Subscription>>({
  email: [
    {required: true, message: 'Please input the email', trigger: 'blur'},
    {min: 3, max: 255, message: 'Length should be 3 to 25', trigger: 'blur'},
  ],

})

const submitForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) return
  await formEl.validate((valid, fields) => {
    if (valid) {
      console.log('submit!')

      api.subscriptions.add(subscription).then(response => {
        console.log(response.data)
        if (response.code == 0) {
          ElMessage({
            message: 'Congrats, this mail has been added successfully!',
            type: 'success',
          })
        } else {
          ElMessage.error(response.message)
        }
      })

      router.push({name: 'Subscriptions'})

    } else {
      ElMessage.error("Oops, Please check the input.")
      console.log('error submit!', fields)
    }
  })
}


</script>