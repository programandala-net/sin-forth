\ lib/value.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1019+0200.

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

: value ( "name" x -- )
  creator
  build-z80dasm-blocks? if dup s" _value_data" z80dasm-cell-block then
  dup , t-!  t-cell t-allot
  does> ( dfa ) @ fthl, push-hl ;

  \ doc{
  \
  \ value
  \   Compilation: ( x "name" -- )
  \   Run-time:    ( -- x )

  \
  \ Compilation: ( "name" -- )
  \
  \ Parse _name_.  Create a definition for _name_, which is referred
  \ to as a "value".  `allot` one `cell` of data space, the data field
  \ of _name_, to hold _x_. When _name_ is later executed, the content
  \ of its data field is placed on the stack.
  \
  \ Run-time: ( -- x )
  \
  \ Place on the stack the content _x_ of data field address of
  \ _name_.

  \ NOTE: In Sin Forth, `value` and `constant` are equivalent.
  \
  \ See also: `to`, `variable`, `constant`, `create`, `allot`.
  \
  \ }doc

set-current set-order
