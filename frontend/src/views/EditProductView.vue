<template>
  <div>
    <el-page-header :icon="ArrowLeft" @back="$router.back()">
    <template #content>
      <span class="text-large font-600 mr-3"> {{slug?'Edit':'Add'}} Product </span>
    </template>
  </el-page-header>
  <br>
  <el-card style="max-width: 600px">
    <el-form :model="product" ref="ruleFormRef" label-width="auto" style="max-width: 600px">
      <el-form-item label="Product name" prop="name" :rules="rules.name">
        <el-input v-model="product.name" />
      </el-form-item>
      <el-form-item label="Product Description" prop="description" >
        <el-input v-model="product.description" type="textarea" />
      </el-form-item>
      <el-form-item label="Product price" prop="price" :rules="rules.price"  >
        <el-input v-model.number="product.price" aria-autocomplete="off" :formatter="(value) => `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
          :parser="(value) => value.replace(/\$\s?|(,*)/g, '')" />
      </el-form-item>
      <el-form-item label="Product Image" prop="imageURL">
        <el-input v-model="product.imageURL" />
      </el-form-item>
      
      <el-form-item label="Product Released" prop="isRelease">
        <el-switch v-model="product.isRelease" />
      </el-form-item>
      
      <el-form-item>
        <el-button type="primary" @click="submitForm(ruleFormRef)">{{slug?'Update':'Add'}}</el-button>
        <el-button @click="$router.push({name:'Product'})">Cancel</el-button>
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

interface ProductForm {
  name: string
  description: string
  isRelease: boolean
  price: number
  imageURL: string
}
const ruleFormRef = ref<FormInstance>()
const product = reactive<ProductForm>({
  name: '',
  description: '',
  isRelease: false,
  price:0,
  imageURL:''
})

const rules =  reactive<FormRules<ProductForm>>({
  name: [
    { required: true, message: 'Please input Product name', trigger: 'blur' },
    { min: 3, max: 255, message: 'Length should be 3 to 25', trigger: 'blur' },
  ],
  price: [
    { required: true, message: 'Please input Product price', trigger: 'blur'},
    { type: 'number', message: 'Price must be a number' },
  ],
})

const submitForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) return
  await formEl.validate((valid, fields) => {
    if (valid) {
      console.log('submit!')
      if(!slug.value){
        axios.post('http://localhost/api/Product/AddProduct',product)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          ElMessage({
            message: 'Congrats, this product has been added!',
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
      }else{
         axios.put('http://localhost/api/Product/'+slug.value,product)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          ElMessage({
            message: 'Congrats, this product has been updated!',
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
        router.push({name:'Product'})
      }
    } else {
      ElMessage.error("Oops, Please check the input.")
      console.log('error submit!', fields)
    }
  })
}


async function fetchArticle(slug: string) {
  await axios.get('http://localhost/api/Product/'+slug)
      .then(response => {
        console.log(response.data);
        const data = response.data;
        if(data.code==0){
          console.log(data.data);
          product.name = data.data.name;
          product.description = data.data.description;
          product.imageURL = data.data.imageURL;
          product.isRelease = data.data.isRelease;
          product.price = data.data.price;
        }else{
          ElMessage.error(data.message)
        }
      })
      .catch(error => {
        console.error(error);
        if(error.response.data.message){
          ElMessage.error(error.response.data.message)
        }else{
          ElMessage.error(error.message)
        }
      });
  
}

onMounted(async () => {
  if (slug.value)
    await fetchArticle(slug.value)
})



</script>
