<template>
    <div>
        <h1>Mail List</h1>
        <div class="mt-4">
        <el-button type="primary" @click="routeToAddSubscriptions">Add</el-button>
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
          <el-table-column prop="id" label="ID" sortable width="180" />
          <el-table-column prop="email" label="Email" sortable />
          <el-table-column prop="createDate" :formatter="formatDemoDate" sortable label="Create Date"  />
          <el-table-column width="360">
          <template #header>
            Operations
          </template>
          <template #default="scope">
            <el-popconfirm
              width="220"
              confirm-button-text="Yes"
              cancel-button-text="No, Thanks"
              icon-color="#626AEF"
              title="Are you sure to remove this email?"
              @confirm="handleDelete(scope.row.email)"
            >
              <template #reference>
                <el-button
                  type="danger"
                >
                  Remove
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
    components: {
      DemoPagination
    },
    data() {
      return {
        queryConfig: { "orderBy": "id", "isDesc": true, "pageIndex": 1,"pageSize": 10 },
        apiData: [],
        lastSearch:null,
      };
    },
    mounted(){
      this.fetchData();
    },
    methods: {
      async fetchData() {
        await axios.post('http://localhost/api/Maillist/GetMailList',this.queryConfig)
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
      handleDelete (email) {
        console.log("handleDelete", email)
        axios.delete('http://localhost/api/MailList/RemoveSubscription',{
          params: {
            email: email,
          },
        })
        .then(response => {
          console.log(response.data);
          const data = response.data;
          if(data.code==0){
            this.fetchData();
            ElMessage({
              message: 'Congrats, this mail has been removed!',
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
      routeToAddSubscriptions(){
        this.$router.push({name:'AddSubscription'})
      },
      formatDemoDate(row, col, value) {
        // Then specify how you want your dates to be formatted
        return this.$formatDate(value,'MM/DD/YYYY');
      }
    }
  }
  </script>

  