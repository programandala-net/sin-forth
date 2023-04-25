\ lib/c-constant.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0753+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require push-a.fs \ `push-a`

get-order get-current

compiler-definitions

: cconstant ( c "name" -- )
  creator
  build-z80dasm-blocks? if dup s" _cconstant_data" z80dasm-char-block then
  dup , t-c!  1 memory> +!
  does> ( dfa ) @ fta, push-a ;

  \ doc{
  \
  \ cconstant ( c "name" -- ) "c-constant"
  \
  \ Parse _name_. Create a definition for _name_ that will place
  \ _c_ on the stack. _name_ is referred to as a "c-constant".
  \
  \ // XXX TODO
  \ // See also: `2constant`, `c!>`, `cconst`,
  \ // `[cconst]`, `cvalue`, `cvariable`.
  \
  \ See also: `cvariable`, `constant`.
  \
  \ }doc

set-current set-order
