\ lib/then.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1335+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require forward-resolve.fs \ `>resolve`

get-order get-current

compiler-definitions

compiler{ synonym then >resolve }

  \ doc{
  \
  \ then
  \   Compilation: ( orig -- )
  \   Run-time:    ( -- )

  \
  \ Resolve the forward reference _orig_, usually left by `if`,
  \ `while` or `after`.
  \
  \ NOTE: ``then`` is implemented as a synonym of `>resolve`.
  \
  \ // XXX TODO See also: `else`, `ahead`.
  \
  \ }doc

set-current set-order
