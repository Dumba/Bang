<template>
  <div class="playerPlace">
    <div class="name">{{ player.name }}</div>
    <Role :player="player" />
    <Character :player="player" />
    <CardPlace :cards="player.cardInHand" class="inHand" :reverseSide="!isMe" />
    <CardPlace :cards="player.cardOnDesk" class="onDesk" />
  </div>
</template>

<script>
import CardPlace from "./CardPlace";
import Character from "./Character";
import Role from "./Role";

export default {
  name: "PlayerPlace",
  components: {
    CardPlace,
    Character,
    Role
  },
  props: {
    player: {}
  },
  computed: {
    isMe() {
      return this.$store.state.login.name == this.player.name;
    }
  }
};
</script>

<style lang="sass">

</style>