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
                    content="Released Products"
                    effect="dark"
                    placement="top"
                >
                  <el-icon :size="12" style="margin-left: 4px">
                    <Warning/>
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
                    content="UnReleased Products"
                    effect="dark"
                    placement="top"
                >
                  <el-icon :size="12" style="margin-left: 4px">
                    <Warning/>
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
    <div>
      <h2>Products:</h2>
      <ProductList :mySize="5"/>
    </div>
    <p/>
    <div>
      <h2>Subscriptions:</h2>
      <SubscriptionList :mySize="5"/>
    </div>
  </div>
</template>

<script lang="ts" setup>
import {Warning} from '@element-plus/icons-vue'
import {ElMessage} from 'element-plus'
import {onMounted, reactive} from 'vue'
import SubscriptionList from '@/components/SubscriptionList.vue'
import ProductList from '@/components/ProductList.vue'
import api, {Statistic} from "@/common/api";

const homeData = reactive<Statistic>({
  releasedProduct: 0,
  unReleasedProduct: 0,
  subscription: 0,
})

async function fetchData() {
  await api.statistic.data().then(data => {
    console.log("response:", data)
    if (data.code == 0) {
      console.log(data.data);
      homeData.releasedProduct = data.data.releasedProduct;
      homeData.unReleasedProduct = data.data.unReleasedProduct;
      homeData.subscription = data.data.subscription;
    } else {
      ElMessage.error(data.message)
    }

  })
}

onMounted(async () => {
  await fetchData()
})
</script>
  
