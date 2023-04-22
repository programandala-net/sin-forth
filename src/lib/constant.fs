\ lib/constant.fs

\ This file is part of Sin Forth.

\ This file adds `constant` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: constant ( "name" x -- )
  creator
  z80dasm-blocks @ if dup s" _constant_data" z80dasm-cell-block then
  dup , t-!  2 memory> +!
  does> ( dfa ) @ fthl, push-hl ;

  \ doc{
  \
  \ constant  Compilation: ( x "name" -- )
  \           Run-time:    ( -- x )
  \
  \ Compilation: ( x "name" -- )
  \
  \ Parse _name_. Create a definition for _name_ that will place _x_
  \ on the stack. _name_ is referred to as a "constant".
  \
  \ Run-time: ( -- x )
  \
  \ Place _x_ on the stack.
  \
  \ // XXX TODO
  \ // See also: `2constant`, `fconstant`, `const`,
  \ // `[const]`, `variable`.
  \ See also: `variable`, `cconstant`, `!>`.
  \
  \ }doc

set-current set-order
