<template>
    <el-footer>
        <el-row>
            <el-col :span="24"><div class="grid-content ep-bg-purple-dark"/>jockhuang@gmail.com</el-col>
            <el-col :span="24"><div class="grid-content ep-bg-purple-dark" />&copy;2024 Jock</el-col>
        </el-row>
        
    </el-footer>
</template>
<style lang="css">
.el-row {
  margin-bottom: 20px;
  text-align:center;
}
.el-row:last-child {
  margin-bottom: 0;
}
.el-col {
  border-radius: 1px;
  text-align: center;
}

.grid-content {
  border-radius: 4px;
  min-height: 24px;
}
</style>