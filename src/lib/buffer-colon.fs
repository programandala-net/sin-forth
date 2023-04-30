\ lib/buffer-colon.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230430T0747+0200.

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

: buffer: ( u "name" -- )
  creator
  build-z80dasm-blocks? if over z80dasm-allot-block then
  , t-allot
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ buffer: ( u "name" -- )

  \ Parse _name_. Create a compiler definition for _name_. Reserve _u_
  \ address units at an aligned address.
  \
  \ When _name_ is subsequently executed, it compiles code that leaves
  \ the address of the reserved space on the target data stack. The
  \ program is responsible for initializing the contents.
  \
  \ See also: `create`, `variable`.
  \
  \ }doc

set-current set-order
