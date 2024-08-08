<template>
     <div>
    <el-row :gutter="16">
      <el-col :span="6">
        <div class="statistic-card">
          <el-statistic :value="homeData.releasedProduct+homeData.unReleasedProduct" title="Total Products">
            <template #title>
              <div style="display: inline-flex; align-items: center">
                Total Products
              </div>
            </template>
          </el-statistic>
        </div>
      </el-col>
      <el-col :span="6">
        <div class="statistic-card">
          <el-statistic :value="homeData.releasedProduct">
            <template #title>
              <div style="display: inline-flex; align-items: center">
                Released Products
                <el-tooltip
                  effect="dark"
                  content="Released Products"
                  placement="top"
                >
                  <el-icon style="margin-left: 4px" :size="12">
                    <Warning />
                  </el-icon>
                </el-tooltip>
              </div>
            </template>
          </el-statistic>
         
        </div>
      </el-col>
      <el-col :span="6">
        <div class="statistic-card">
          <el-statistic :value="homeData.unReleasedProduct">
            <template #title>
              <div style="display: inline-flex; align-items: center">
                UnReleased Products
                <el-tooltip
                  effect="dark"
                  content="UnReleased Products"
                  placement="top"
                >
                  <el-icon style="margin-left: 4px" :size="12">
                    <Warning />
                  </el-icon>
                </el-tooltip>
              </div>
            </template>
          </el-statistic>
          
        </div>
      </el-col>
      <el-col :span="6">
        <div class="statistic-card">
          <el-statistic :value="homeData.subscription" title="Total Subscriptions users">
            <template #title>
              <div style="display: inline-flex; align-items: center">
                Total Subscriptions users
              </div>
            </template>
          </el-statistic>
        </div>
      </el-col>
    </el-row>
    
    </div>
  </template>
  
  <script lang="ts" setup>
  import {Warning} from '@element-plus/icons-vue'
  import axios from 'axios';
  import { ElMessage } from 'element-plus'
  import { onMounted,reactive } from 'vue'


  interface HomeData {
    releasedProduct: number
    unReleasedProduct: number
    subscription: number
  }

  const homeData = reactive<HomeData>({
    releasedProduct: 0,
    unReleasedProduct:0,
    subscription: 0,
   
    })

  async function fetchData() {
  await axios.get('http://localhost/api/Statistic/')
      .then(response => {
        console.log(response.data);
        const data = response.data;
        if(data.code==0){
          console.log(data.data);
          homeData.releasedProduct = data.data.releasedProduct;
          homeData.unReleasedProduct = data.data.unReleasedProduct;
          homeData.subscription = data.data.subscription;
          
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
    await fetchData()
})
  </script>
  
