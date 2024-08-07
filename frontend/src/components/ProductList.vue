
<template >
    <div>
      <h1>Product List</h1>
      <div class="mt-4">
        <el-button type="primary" @click="routeToAddProduct">Add</el-button>
        <el-input
          v-model="queryConfig.search"
          style="max-width: 600px"
          placeholder="Type to search"
          @input="searchData"
        >
          <template #prepend>
            <el-button :icon="Search" />
          </template>
          <template #append>
            <el-button type="primary" @click="searchData">Search</el-button>
            
          </template>
        </el-input>
      </div>
      <el-table stripe
        :data="apiData.items"
        :default-sort="{ prop: 'id', order: 'descending' }"
        @sort-change="changeOrder" 
        style="width: 100%"
      >
      
        <el-table-column prop="id" label="ID" sortable width="80" />
        <el-table-column prop="name" label="Name" sortable width="400" show-overflow-tooltip />
        <el-table-column prop="description" sortable label="Description"  show-overflow-tooltip/>
        <el-table-column prop="price" sortable label="Price" width="120"/>

        <el-table-column prop="isRelease" sortable label="Released" width="80">

          <template #default="scope">
            <el-switch
              v-model="scope.row.isRelease"
              size="small"
              disabled
            />
            <!-- <el-col :sm="1" :lg="1">
            <el-result :icon="scope.row.isRelease ? 'success' : 'error'" />
            </el-col> -->
          </template>
        </el-table-column>
        <el-table-column prop="createDate" :formatter="formatDemoDate" sortable label="Create Date" width="180"/>
        <el-table-column prop="updateDate" :formatter="formatDemoDate" sortable label="Update Date" width="180"/>
        <el-table-column width="360">
          <template #header>
            Operations
          </template>
          <template #default="scope">
            <el-button @click="handleEdit(scope.row.id)">
              Edit
            </el-button>
            <el-popconfirm
              width="220"
              confirm-button-text="Yes"
              cancel-button-text="No, Thanks"
              icon-color="#626AEF"
              title="Are you sure to delete this?"
              @confirm="handleDelete(scope.row.id)"
            >
              <template #reference>
                <el-button
                  type="danger"
                >
                  Delete
                </el-button>
              </template>
            </el-popconfirm>
          </template>
        </el-table-column>
      </el-table>
      
      <DemoPagination :pageIndex="queryConfig.pageIndex" :pageSize="queryConfig.pageSize" :totalCount="apiData.totalCount" @change-page-config="changePageConfig"/>
    </div>
</template>
<script setup>
import { Search } from '@element-plus/icons-vue'
import axios from 'axios';
import DemoPagination from "./Pagination.vue";
import { ElMessage } from 'element-plus'
</script>
<script>
export default {
  name: "DemoProductList",
  components: {
    DemoPagination
  },

  data() {
    return { 
      queryConfig: { "search":"", "orderBy": "id", "isDesc": true, "pageIndex": 1,"pageSize": 10 },
      apiData: [],
      lastSearch:null,
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    async fetchData() {
      console.log(this.queryConfig);
      await axios.post('http://localhost/api/Product/QueryProducts',this.queryConfig)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          this.apiData = data.data;
          
        })
        .catch(error => {
          console.error(error);
        });
    },
    changePageConfig(newPageIndex,newPageSize) {
      this.queryConfig.pageIndex =newPageIndex;
      this.queryConfig.pageSize = newPageSize;
      this.fetchData();
    },
    changeOrder(orderOp){
      console.log(orderOp);
      this.queryConfig.orderBy = orderOp.prop;
      if(orderOp.order == "descending"){
        this.queryConfig.isDesc = true;
      }else if(orderOp.order == "ascending"){
        this.queryConfig.isDesc = false;
      }else{
        this.queryConfig.isDesc = false;
        this.queryConfig.orderBy="id";
      
      }
        
      this.fetchData();
    },
    searchData(){
      clearTimeout(this.lastSearch);
      this.lastSearch = setTimeout(() => {
        this.fetchData();
        }, 700); 
    },
    formatDemoDate(row, col, value) {
      // Then specify how you want your dates to be formatted
      return this.$formatDate(value,'MM/DD/YYYY');
    },
    handleEdit(id){
      console.log("handleEdit", id)
      this.$router.push({ name: 'EditProduct', params: { slug: id } })

    },
    handleDelete (id) {
      console.log("handleDelete", id)
      axios.delete('http://localhost/api/Product/'+id)
      .then(response => {
        console.log(response.data);
        const data = response.data;
        if(data.code==0){
          this.fetchData();
          ElMessage({
            message: 'Congrats, this product has been deleted!',
            type: 'success',
          })
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
     
    },
    routeToAddProduct(){
      this.$router.push({name:'AddProduct'})
    }
 
  }
}
</script>
