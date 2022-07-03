<template>
<div>
  <el-table
    :data="tableData"
    style="width: 100%">
    <el-table-column
      prop="roleId"
      label="角色Id"
      width="180">
    </el-table-column>
     <el-table-column
      prop="roleName"
      label="角色名称"
      width="180">
    </el-table-column>
    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button
          size="mini"
          @click="Distribution(scope.row.roleId)">分配权限</el-button>
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
  <el-dialog title="菜单" :visible.sync="dialogTableVisible">
    <menuTree ref="dialogTree" />
    <div slot="footer" class="dialog-footer">
    <el-button @click="dialogTableVisible = false">取 消</el-button>
    <el-button type="primary" @click="SavePermission">确 定</el-button>
  </div>
  </el-dialog>
  </div>
</template>

<script>
import menuTree from '@/views/Role/tree.vue'
  export default {
    components: {
    menuTree,
    },
    data() {
      return {
        tableData: [],
        dialogTableVisible:false,
        MenuRole:{
          roleId:0,
          menuId:[]
        }
      }
    },
    methods: {
      handleEdit(index, row) {
        console.log(index, row);
      },
      handleDelete(index, row) {
        console.log(index, row);
      },
      Distribution(roleId){
        this.MenuRole.roleId = roleId;
        this.dialogTableVisible = true;
      },
      GetShow(){
        this.$axios.get('https://localhost:44340/api/Role/Show')
        .then(res =>{
          
            this.tableData = res.data;
            debugger
        })
      },
      SavePermission(){
        this.MenuRole.menuId= this.$refs["dialogTree"].$refs["menuTree"].getCheckedNodes(true,true).map(m=>m.value);
        this.$axios.post('https://localhost:44340/api/Role/SavePermission',this.MenuRole)
        .then(res =>{
             this.$message({
                message: '分配成功',
                type: 'success',
                onClose:(m=>{
                  this.GetShow();
                })
              });
        })
      }
    },
    created(){
        this.GetShow();
    }
  }
</script>
