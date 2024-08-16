<template>
  <div>
    <el-page-header :icon="ArrowLeft" @back="$router.back()">
      <template #content>
        <span class="text-large font-600 mr-3"> {{ slug ? 'Edit' : 'Add' }} Product </span>
      </template>
    </el-page-header>
    <br>
    <el-card style="max-width: 600px">
      <el-form ref="ruleFormRef" :model="product" label-width="auto" style="max-width: 600px">
        <el-form-item :rules="rules.name" label="Product name" prop="name">
          <el-input v-model="product.name"/>
        </el-form-item>
        <el-form-item label="Product Description" prop="description">
          <el-input v-model="product.description" type="textarea"/>
        </el-form-item>
        <el-form-item :rules="rules.price" label="Product price" prop="price">
          <el-input v-model.number="product.price" :formatter="(value) => `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                    :parser="(value) => value.replace(/\$\s?|(,*)/g, '')"
                    aria-autocomplete="off"/>
        </el-form-item>
        <el-form-item label="Product Image" prop="imageURL">
          <el-input v-model="product.imageURL"/>
        </el-form-item>

        <el-form-item label="Product Released" prop="isRelease">
          <el-switch v-model="product.isRelease"/>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="submitForm(ruleFormRef)">{{ slug ? 'Update' : 'Add' }}</el-button>
          <el-button @click="$router.push({name:'Product'})">Cancel</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script lang="ts" setup>
import type {FormInstance, FormRules} from 'element-plus'
import {ElMessage} from 'element-plus'
import {computed, onMounted, reactive, ref} from 'vue'
import {useRoute, useRouter} from 'vue-router'
import api, {Product} from "@/common/api"
import {ArrowLeft} from '@element-plus/icons-vue'

const route = useRoute()
const router = useRouter()
const slug = computed<string>(() => route.params.slug as string)

const ruleFormRef = ref<FormInstance>()
const product = reactive<Product>({
  name: '',
  description: '',
  isRelease: false,
  price: 0,
  imageURL: ''
})

const rules = reactive<FormRules<Product>>({
  name: [
    {required: true, message: 'Please input Product name', trigger: 'blur'},
    {min: 3, max: 255, message: 'Length should be 3 to 25', trigger: 'blur'},
  ],
  price: [
    {required: true, message: 'Please input Product price', trigger: 'blur'},
    {type: 'number', message: 'Price must be a number'},
  ],
})

const submitForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) return
  await formEl.validate((valid, fields) => {
    if (valid) {
      console.log('submit!', slug, product)
      let responsePromise;
      if (!slug.value) {
        responsePromise = api.products.add(product)
      } else {
        responsePromise = api.products.update(slug.value, product)

      }
      responsePromise.then(response => {
        console.log(response.data)
        if (response.code == 0) {
          ElMessage({
            message: 'Congrats, this product has been added successfully!',
            type: 'success',
          })
        } else {
          ElMessage.error(response.message)
        }
      })

      router.back()
    } else {
      ElMessage.error("Oops, Please check the input.")
      console.log('error submit!', fields)
    }
  })
}


async function fetchProduct(slug: string) {
  await api.products.details(slug).then(response => {
    if (response.code == 0) {
      product.name = response.data.name
      product.description = response.data.description
      product.price = response.data.price
      product.imageURL = response.data.imageURL
      product.isRelease = response.data.isRelease
    } else {
      ElMessage.error(response.message)
    }
  })

}

onMounted(async () => {
  if (slug.value)
    await fetchProduct(slug.value)
})


</script>
