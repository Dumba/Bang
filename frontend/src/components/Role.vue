<template>
  <div class="role">
    <img v-if="show" :src="`/cards/roles/${player.role}.png`" :alt="player.role" />
    <img v-else src="/cards/roles/back-role.png" alt="role" />
  </div>
</template>

<script>
export default {
  name: "Role",
  props: {
    player: {}
  },
  computed: {
    show() {
      return (this.$store.state.login.name == this.player.name) || (this.player.role == "sheriff");
    }
  }
}
</script>

<style lang="sass">
@import ../style

.role
  height: $cardHeight
  place-self: center
  img
    height: 100%
</style>