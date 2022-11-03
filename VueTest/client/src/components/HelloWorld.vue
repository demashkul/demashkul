
<script>
import useVuelidate from '@vuelidate/core'
import { required, email, minLength, helpers } from '@vuelidate/validators'
const mustBeCool = (value) => { console.log(value); return value.includes('cool') }
export default {
  setup() {
    return { v$: useVuelidate() }
  },
  validations: {
    people: {
      // required, // array cannot be left empty
      // minLength: minLength(6), // "values" array has to have at least 6 elements
      $each: helpers.forEach({
        firstName: {
          required,
          mustBeCool:(value) => { console.log(value); return value.includes('cool') },
          minLength: minLength(4),
          //$lazy: true
        },
        //firstName:mustBeCool
        
      })
    },
    tesm: { required }
  },
  data() {
    return {
      people: [{     // initialize as empty for showing the empty inputs 
        firstName: "asd",
        email: ""
      },
      {     // initialize as empty for showing the empty inputs 
        firstName: "qwe2",
        email: null
      }]
      , tesm: "asd"
    }
  },
  methods: {
    validate: function () {
      this.v$.$touch();
    },
    add: function () {
      this.people.add({
        firstName: "",
        email: ""
      })
    },

    remove: function (index) {
      if (this.people.length === 1) {
        this.people.splice(0, 1, {
          firstName: "",
          email: ""
        });
      } else {
        this.people.splice(index, 1);
      }
    }
  }
}
</script>

<template>
  <pre>{{v$.$invalid}}</pre>
  <div v-for="(person, index) in people">
    <pre>Email len {{people[index].email?.length}}</pre>
    <input type="text" v-model="people[index].firstName" />
    <input type="text" v-model="people[index].email" />
    <span class="error" v-if="v$.people.$model[index].firstName.$invalid">Email is required</span>
    <button v-on:click="remove(index)">Remove</button>
  </div>
  <button v-on:click="validate()">Validate</button>
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
