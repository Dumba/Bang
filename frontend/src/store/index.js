import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    login: {
      name: "pepa"
    },
    players: {
      pepa: {
        name: "pepa",
        role: "deputy",
        character: "willy-the-kid",
        hp: 4,
        cardInHand: [
          1, 2
        ],
        cardOnDesk: [
          3, 4
        ]
      },
      karel: {
        name: "karel",
        role: "sheriff",
        character: "suzy-lafayette",
        hp: 5,
        cardInHand: [ 2 ],
        cardOnDesk: [ 3 ]
      },
      josef: {
        name: "josef",
        role: "outlaw",
        character: "pedro-ramirez",
        hp: 2,
        cardInHand: [],
        cardOnDesk: [ 2 ]
      },
      jana: {
        name: "jana",
        role: "vice",
        character: "vulture-sam",
        hp: 1,
        cardInHand: [],
        cardOnDesk: [ 2 ]
      }
    },
    cardsOnDesk: [ 5 ],
    packToTake: [ 6 ],
    packToLeave: [ 7 ],

    // static
    cards: {
      1: {
        type: "appaloosa",
        color: "4S"
      },
      2: {
        type: "bang",
        color: "5S"
      },
      3: {
        type: "barrel",
        color: "4K"
      },
      4: {
        type: "beer",
        color: "4K"
      },
      5: {
        type: "carabine",
        color: "4K"
      },
      6: {
        type: "catbalou",
        color: "4K"
      },
      7: {
        type: "diligenza",
        color: "4K"
      }
    }
  },
  mutations: {
    moveCards: (state, payload) => { // source { type, player, place }, target, card
      var source = state[payload.source.type];
      if (payload.source.player != null && payload.source.place != null)
        source = source[payload.source.player][payload.source.place];

      var target = state[payload.target.type];
      if (payload.target.player != null && payload.target.place != null)
        target = target[payload.target.player][payload.target.place];

      var card = source.pop(payload.card);
      target.push(card);
    },
    changeLives: (state, payload) => { // count
      state.players[state.login.name].hp += payload.count;
    }
  },
  actions: {
    moveCards: (context, payload) => {
      // TODO: send
      context.commit('moveCands', payload);
    },
    changeLives: (context, payload) => {
      // TODO: send
      context.commit('changeLives', payload);
    }
  },
  modules: {
  }
})
