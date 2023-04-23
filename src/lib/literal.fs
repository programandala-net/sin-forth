\ lib/literal.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

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

: literal ( x -- )
  h ldp#, \ ld hl,x
  push-hl ;

  \ doc{
  \
  \ literal
  \   Compilation: ( x -- )
  \   Run-time:    ( -- x )
  \
  \ Compilation: ( x -- )
  \
  \ Compile the code required to put cell _x_ on the stack at run-time.
  \
  \ Run-time: ( -- x )
  \
  \ Return the compiled cell _x_.
  \
  \ // XXX TODO
  \ // See also: `lit`, `cliteral`, `2literal`, `xliteral`.
  \
  \ }doc

set-current set-order
