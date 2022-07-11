<template>
    <div>
<el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
  <el-form-item label="账号" prop="userName">
    <el-input v-model="ruleForm.userName"></el-input>
  </el-form-item>
   <el-form-item label="密码" prop="password">
    <el-input v-model="ruleForm.password"></el-input>
  </el-form-item>
  <el-form-item label="邮箱" prop="email">
    <el-input v-model="ruleForm.email"></el-input>
  </el-form-item>
  <el-form-item label="角色">
    <el-select v-model="ruleForm.roleId" multiple placeholder="请选择">
     <el-option
      v-for="item in options"
      :key="item.roleId"
      :label="item.roleName"
      :value="item.roleId">
    </el-option>
    </el-select>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
    <el-button @click="resetForm('ruleForm')">重置</el-button>
  </el-form-item>
</el-form>
</div>
</template>
<script>
  export default {
    data() {
      return {
        options:[],
        ruleForm: {
          userName: '',
          password: '',
          email:'',
          roleId:[]
        },
        rules: {
          userName: [
            { required: true, message: '请输入账号', trigger: 'blur' }
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],
          email: [
            { required: true, message: '请输入邮箱', trigger: 'change' }
          ],
        }
      };
    },
    methods: {
      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            this.$axios.post('https://localhost:44340/api/Admins/Register',this.ruleForm)
        .then(res =>{
            
                this.$message.success('添加成功');
                this.GetShow();
        })
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
      GetShow(){
        this.$axios.get('https://localhost:44340/api/Role/Show')
        .then(res =>{
            this.options = res.data;
        })
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
    },
    created(){
        this.GetShow();
    }
  }
</script>