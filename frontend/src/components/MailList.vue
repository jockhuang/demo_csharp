<template>
    <div>
        <h1>Mail List</h1>
        <el-table stripe
          :data="apiData.items"
          :default-sort="{ prop: 'id', order: 'ascending' }"
          @sort-change="changeOrder"
          style="width: 100%"
        >
          <el-table-column prop="id" label="ID" sortable width="180" />
          <el-table-column prop="email" label="Email" sortable />
          <el-table-column prop="createDate" :formatter="formatDemoDate" sortable label="Create Date"  />
        </el-table>
        <DemoPagination :pageIndex="queryConfig.pageIndex" :pageSize="queryConfig.pageSize" :totalCount="apiData.totalCount" @change-page-config="changePageConfig"/>
      </div>
  </template>
  <script>
  import axios from 'axios';
  import DemoPagination from './Pagination.vue'
  
  export default {
    components: {
      DemoPagination
    },
    data() {
      return {
        queryConfig: { "orderBy": "id", "isDesc": false, "pageIndex": 1,"pageSize": 5 },
        apiData: [],
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
      formatDemoDate(row, col, value) {
        // Then specify how you want your dates to be formatted
        return this.$formatDate(value,'MM/DD/YYYY');
      }
    }
  }
  </script>
  <style>
  @media (min-width: 1024px) {
    .about {
      min-height: 100vh;
      display: flex;
      align-items: center;
    }
  }
  </style>
  