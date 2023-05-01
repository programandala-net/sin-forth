\ lib/to.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230501T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl.fs \ `pop-hl`
require tick.fs   \ `'`

get-order get-current

compiler-definitions

: to ( x "name" -- )
  pop-hl \ compile `call pop_hl` to move _x_ from the target data stack to HL
  compiler{ ' } \ get the address of _name_ on the host data stack
  sthl, ; \ compile `ld (a),hl` and `ret`

  \ doc{
  \
  \ to
  \   Compilation: ( "name" -- )
  \   Run-time:    ( x -- )

  \ Compilation: ( "name" -- )
  \
  \ Parse _name_, which is a word defined by `value`.  Compile the
  \ run-time semantics defined below.
  \
  \ Run-time: ( x -- )
  \
  \ Place _x_ into the data field address of _name_.

  \ See also: `variable`, `constant`, `create`, `t-allot`.
  \
  \ }doc

set-current set-order
