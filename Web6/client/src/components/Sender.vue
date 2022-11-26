<script>
import * as messageService from '../services/messageService.js';
export default {
  data() {
    return {
      value: '',
      ops: [
        { name: 'The 1 Volar', code: 'op1' },
        { name: 'The 2 Visual Studio Keymap', code: 'op2' },
        { name: 'The 3 Rainbow Brackets', code: 'op3' },
      ],
      dto:{
        title:'test',
        content:'',
        via:''
      }
    }
  },
  methods:{
    async save(){
      await messageService.save(this.dto);

    }
  }
}
</script>

<template>
  {{value}}
  <div class="grid">
    <div class="col-12">
      <InputText type="text" v-model="dto.content" />
    </div>
    <div class="col-12">
      <Dropdown v-model="dto.via" :options="ops" optionLabel="name" optionValue="code" placeholder="Choose" />
    </div>
    <div class="col-12">
      <Button @click="save" value="Kaydet" />
    </div>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {

  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
