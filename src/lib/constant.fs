\ lib/constant.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230501T1112+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: constant ( "name" x -- )
  creator
  build-z80dasm-blocks? if dup s" _constant_data" z80dasm-cell-block then
  dup , t-!  t-cell t-allot
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
  \ NOTE: In Sin Forth, `constant` and `value` are equivalent.
  \ This means that also the value of a constant can be changed by
  \ `to`.
  \
  \ // XXX TODO
  \ // See also: `2constant`, `fconstant`, `const`,
  \ // `[const]`, `variable`.
  \ See also: `variable`, `cconstant`.
  \
  \ }doc

set-current set-order
