\ lib/while.fs
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

require if.fs \ `if`

get-order get-current

compiler-definitions

: while \ Compilation: ( dest -- orig dest )
        \ Run-time:    ( f -- )
  compiler{ if } swap ;

  \ doc{
  \
  \ while
  \   Compilation: ( dest -- orig dest )
  \   Run-time:    ( f -- )

  \ Compilation: Put the location of a new unresolved forward
  \ reference _orig_ onto stack, under the existing _dest_. Usually
  \ _orig_ and _dest_ are resolved by `repeat`.
  \
  \ Run-time: If _f_ is zero, continue execution at the location
  \ specified by the resolution of _orig_.
  \
  \ // XXX TODO
  \ // See also: `if`, `until`, `cs-swap`, `postpone`, `0while`, `-while`, `+while`.
  \ See also: `if`, `until`.
  \
  \ }doc

set-current set-order
