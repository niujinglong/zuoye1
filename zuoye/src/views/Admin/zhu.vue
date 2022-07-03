<template>
<el-card class="box-card">
  <div slot="header" class="clearfix">
    <span>注册</span>
  </div>
  <div>
    <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
  <el-form-item label="账号" prop="userName">
    <el-input v-model="ruleForm.userName"></el-input>
  </el-form-item>
  <el-form-item label="密码" prop="password">
    <el-input type="password" v-model="ruleForm.password"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
  </el-form-item>
</el-form>
  </div>
</el-card>
</body>
</template>
<script>
  export default {
    data() {
      return {
        ruleForm: {
          userName: '',
          password: '',
        },
        rules: {
          userName: [
            { required: true, message: '请输入账号', trigger: 'blur' },
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'blur' }
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
                let loginfo = res.data;
                if(loginfo.code > 0)
                {
                    this.$message.error(loginfo.msg);
                }
                else{
                    this.$message.success('注册成功');
                    this.$router.push('/login')
                }
            })
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
    }
  }
</script>

<style>
  .text {
    font-size: 14px;
    
  }


  .item {
    margin-bottom: 18px;
    
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
    
  }
  .clearfix:after {
    clear: both,
  }

  .box-card {
    width: 480px;
    margin-top: 15%;
    margin-left: 30%;
    background-color: aquamarine;
  }
</style>